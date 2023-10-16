using ConsoleApp.PostgreSQL;
using MailKitSimplified.Sender.Models;
using MailKitSimplified.Sender.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration; 
    }

    public IConfiguration Configuration {get;}

    public void ConfigureServices (IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddRazorPages();

        //Configure the EmailSenderOptions using data from appsettings.json
        services.Configure<EmailSenderOptions>(Configuration.GetSection("EmailSenderOptions"));

        //Create a factor to instantiate SmtpSender using EmailSenderOptions
        services.AddSingleton<ISmtpSenderFactory, SmtpSenderFactory>();
    } 

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}