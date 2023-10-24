// Public class for Menu Items 
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotCorner.Model
{
    public class MenuItem 
    {   
        //Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [MaxLength(255)]
        public required string Name {get; set;}
        [MaxLength(500)]
        public required string Description {get; set;}
        [DataType(DataType.Currency)]
        public required decimal Price {get; set;}
        [MaxLength(50)]
        public required string Category {get; set;}
        public required ICollection<Ingredient> Ingredients {get; set;}
        public List<string>? ImageUrls {get; set;}
        
        //MenuItem Constructors
        public MenuItem()
        {
            Ingredients = new List<Ingredient>();
            ImageUrls = new List<string>();
        }


        public MenuItem(string name, string description, decimal price, string category, List<Ingredient> ingredients, List<string>? imageUrls)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Ingredients = ingredients;
            ImageUrls = imageUrls;
        }

        //Methods


        //AddIngredient: Add ingredient to the list of ingredients used in a menu item 
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        //RemoveIngredient: Remove ingredient from the list of ingredients used in a menu item
        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        //UpdatePrice: Update the price of the menu item
        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }

        //AddImageUrl: Add image to list for menu item
        public void AddImageUrl(string imageUrl)
        {
            ImageUrls.Add(imageUrl);

        }

        //RemoveImageUrl: Remove an image Url from list
        public void RemoveImageUrl(string imageUrl)
        {
            ImageUrls.Remove(imageUrl);
        }

        //UpdateDescription: Update the description of the menu item
        public void UpdateDescription(string description)
        {
            Description = description;
        }

        //AddToCategory: Categorize menu item
        public void AddToCategory(string category)
        {
            Category = category;
        }

        //Clone: Create a copy of a menu item with the same properties
        public MenuItem Clone()
        {
            return new MenuItem
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Category = Category,
                Ingredients = new List<Ingredient>(Ingredients),
                ImageUrls = new List<string>(ImageUrls)
            };
        }
    }
}
