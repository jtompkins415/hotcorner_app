//Public class for Orders

using System;
using System.ComponentModel.DataAnnotations;


public class Order
{
    //Properties
    [Key]
    public Guid OrderId {get; set;}
    public int OrderNum {get; set;}
    public Guid EmployeeId {get; set;}
    public string EmployeeName {get; set;}
    public DateTime OrderTime {get; set;}
    public Guid TableId {get; set;}
    public int TableNumber {get; set;}
    public List<OrderItem> OrderItems {get; set;}
    public string Status {get; set;}
    public decimal TotalPrice {get; set;}

    //Constructors & Nested Classes

    public class OrderItem
    {
        //Properties
        public Guid MenuItemId {get; set;}
        public string MenuItemName {get; set;}
        public int Quantity {get; set;}
    }
}