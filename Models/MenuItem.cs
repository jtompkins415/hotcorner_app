// Public class for Menu Items 
using System;
using System.ComponentModel.DataAnnotations;
public class MenuItem 
{   
    //Properties

    [Key]
    public int Id {get; set;}
    [MaxLength(255)]
    public required string Name {get; set;}
    [MaxLength(500)]
    public required string Description {get; set;}
    [DataType(DataType.Currency)]
    public required decimal Price {get; set;}
    [MaxLength(50)]
    public required string Category {get; set;}
    public required List<Ingredient> Ingredients {get; set;}
    public List<string>? ImageUrls {get; set;}
    
    //MenuItem Constructors
     public MenuItem()
    {
        Ingredients = new List<Ingredient>();
        ImageUrls = new List<string>();
    }


    public MenuItem(int id, string name, string description, decimal price, string category, List<Ingredient> ingredients, List<string>? imageUrls)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Ingredients = ingredients;
        ImageUrls = imageUrls;
    }
}