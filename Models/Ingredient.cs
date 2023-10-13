// Public class for Ingredients
using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    //Properties
    [Key]
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public int Quantity {get; set;}
    public char Unit {get; set;}


    //Constructors
    public Ingredient()
    {}

    public Ingredient(string name, int quantity, char unit)
    {
        Id = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    //Methods


}   