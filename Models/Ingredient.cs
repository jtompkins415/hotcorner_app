// Public class for Ingredients
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

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

    // IncreaseQuantity: Increase the quantity of an ingredient 
    public void IncreaseQuantity(int amount)
    {
        Quantity += amount;
    }

    // DecreaseQuantity: Decrease the quantity of an ingredient
    public void DecreaseQuantity(int amount)
    {   
        if (Quantity >= amount)
        {
            Quantity -= amount;
        } else
        {
           throw new InvalidOperationException("Not enough quantity to decrease");
        }
    }

    // IsAvailable: Checks if there is enough quantity of an ingredient for a recipe
    public bool IsAvailable(int requiredAmount)
    {
        return Quantity >= requiredAmount;
    }

    // Clone: Clones an instance of an ingredient
    public Ingredient Clone()
    {
       return new Ingredient
       {
        Name = Name,
        Quantity = Quantity,
        Unit = Unit
       };
    }

}   