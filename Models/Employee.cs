//Public class for Employee

using System;
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
        public string EmployeeName {get; set;}
        [MaxLength(255)]
        public string EmployeeEmail {get; set;}
        public string Department {get; set;}
        public string Position {get; set;}
        
    }
}
