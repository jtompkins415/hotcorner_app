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
        public decimal MenuItemPrice {get; set;}
        public int Quantity {get; set;}
    }

    public Order()
    {
        OrderItems = new List<OrderItem>();
    }

    public Order(int orderNum, Employee employee, DateTime orderTime, Table table, List<OrderItem> orderItems, string status, decimal totalPrice)
    {
        OrderId = Guid.NewGuid();
        OrderNum = orderNum;
        EmployeeId = employee.EmployeeId;
        EmployeeName = employee.EmployeeName;
        OrderTime = orderTime;
        TableId = table.TableId;
        TableNumber = table.TableNumber;
        OrderItems = orderItems;
        Status = status;
        TotalPrice = totalPrice;
    }

    //Methods

    //AddItem: Allows adding a new item to the order
    public void AddItem(MenuItem menuItem, int quantity)
    {
        //Add specified item to the order's list of items
        OrderItems.Add(new OrderItem
        {
            MenuItemId = menuItem.Id,
            MenuItemName = menuItem.Name,
            MenuItemPrice = menuItem.Price,
            Quantity = quantity

        });
    }

    //RemoveItem: Allows removal of an item from the order based on the menu item ID
    public void RemoveItem(MenuItem menuItem)
    {
        //Find and remove the item with the specified ID
        var itemToRemove = OrderItems.FirstOrDefault(item => item.MenuItemId == menuItem.Id);
        if(itemToRemove != null)
        {
            OrderItems.Remove(itemToRemove);
        }
    }

    /*CalculateTotalPrice: Calculates the total price of the order based on the individual items and their quanities;
        Updates the `TotalPrice` property
    */
    public void CalculateTotalPrice()
    {
        TotalPrice = OrderItems.Sum(item => item.Quantity * item.MenuItemPrice);
    }

    //ChangeStatus: Changes the status of the order
    public void ChangeStatus(string newStatus)
    {
        Status = newStatus;
    }

    
}