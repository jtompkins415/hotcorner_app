//Public class for Employee

using System;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    //Properties
    [Key]
    public Guid EmployeeId {get; set;}
    [MaxLength(255)]
    public string EmployeeName {get; set;}
    [MaxLength(255)]
    public string EmployeeEmail {get; set;}
    public string Department {get; set;}
    public string Position {get; set;}
    
}