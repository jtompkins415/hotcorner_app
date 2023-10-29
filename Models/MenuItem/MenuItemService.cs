// Public class for CRUD operations on the MenuItems table
                             
using Microsoft.EntityFrameworkCore;
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
        public async Task AddMenuItemAsync(MenuItem? menuItem)
        {
            try
            {
                if(menuItem != null)
                {
                    _context.MenuItems.Add(menuItem);
                    await _context.SaveChangesAsync();
                }
                
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            
        }


        //ReadMenuItemAsync: Returns MenuItem based on a given ID
        public async Task<MenuItem?> ReadMenuItemAsync(int menuItemId)
        {
            MenuItem? menuItem = await _context.MenuItems.FindAsync(menuItemId);
            return menuItem;
        }

        //RemoveMenuItemAsyc: Remove MenuItem by ID
        public async Task RemoveMenuItemAsync(int menuItemId)
        {   
            MenuItem? menuItem = await _context.MenuItems.FindAsync(menuItemId);

            if(menuItem != null)
            {
                _context.Remove(menuItem);
                await _context.SaveChangesAsync();  
            }
            
        }

        //UpdateMenuItemAsync: Update properties of an existing MenuItem
        public async Task<bool> UpdateMenuItemAsync(
            int menuItemId,
            string? name = null,
            string? description = null,
            decimal? price = null,
            string? category = null
        )
        {
            MenuItem? itemToUpdate = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == menuItemId);

            if(itemToUpdate == null)
            {
                return false;
            }

            if(name != null)
            {
                itemToUpdate.Name = name;
            }
            if(description != null)
            {
                itemToUpdate.Description = description;
            }
            if(price != null)
            {
                itemToUpdate.Price = price.Value;
            }
            if(category != null)
            {
                itemToUpdate.Category = category;
            }

            _context.Update(itemToUpdate);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
