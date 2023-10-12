//Public class for Tables

using System.ComponentModel.DataAnnotations;

public class Table
{
    [Key]
    public int Id {get; set;}
    public required int TableNumber {get; set;}
    public required int SeatingCapacity {get; set;}
    public required string Status {get; set;}
}