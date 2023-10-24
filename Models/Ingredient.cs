// Public class for Ingredients
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace HotCorner.Model
{
    public class Ingredient
    {
        //Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public required string Name {get; set;}
        public int Quantity {get; set;}
        public char Unit {get; set;}
        public ICollection<MenuItem> MenuItemsIncluded {get; set;}


        //Constructors
        public Ingredient()
        {
            MenuItemsIncluded = new List<MenuItem>();
        }

        public Ingredient(string name, int quantity, char unit)
        {
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
}
   