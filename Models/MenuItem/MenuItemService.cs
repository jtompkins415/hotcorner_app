// Public class for CRUD operations on the MenuItems table

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ConsoleApp.PostgreSQL;

namespace HotCorner.Model
{
    public class MenuItemService
    {
        private readonly AppDbContext _context;

        public MenuItemService(AppDbContext context)
        {
            _context = context;
        }

        //AddMenuItemAsync: Add new MenuItem to MenuItems Table
        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMenuItemAsync(int menuItemId)
        {   
            MenuItem menuItem = await _context.MenuItems.FindAsync(menuItemId);
            _context.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
