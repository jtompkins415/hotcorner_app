//Public class for Employee

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotCorner.Model
{
    public class Employee
    {
        //Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId {get; set;}
        [MaxLength(255)]
        public required string EmployeeName {get; set;}
        [MaxLength(255)]
        public required string EmployeeEmail {get; set;}
        public required string Department {get; set;}
        public required string Position {get; set;}
        public required decimal Salary {get; set;}
        public required string Status {get; set;}

        

        //Constructor

        public Employee()
        {}

        public Employee(string name, string email, string department, string position, decimal salary, string status)
        {
            EmployeeName = name;
            EmployeeEmail = email;
            Department = department;
            Position = position;
            Salary = salary;
            Status = status;
        } 
    }
}
