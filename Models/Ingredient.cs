// Public class for Ingredients
using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    [Key]
    public int Id {get; set;}
    public required string Name {get; set;}
    public int Quantity {get; set;}
    public char Unit {get; set;}
}   