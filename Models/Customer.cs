//Public class for Customers
using System;
using System.ComponentModel.DataAnnotations;
public class Customer
{
    //Properties
    [Key]
    public Guid CustomerId {get; set;}
    
    [MaxLength(255)]
    public required string Name {get; set;}

    [MaxLength(255)]
    public required string Email {get; set;}

    public int LoyaltyPoints {get; set;}


}