//Public class for Tables
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotCorner.Model
{
    public class Table
    {
        //Properties 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId {get; set;}
        public required int TableNumber {get; set;}
        public required int SeatingCapacity {get; set;}
        public required string Status {get; set;}

        //Constructors

        public Table()
        {}

        public Table(int tableNumber, int seatingCapacity, string status)
        {
            TableNumber = tableNumber;

            if(!IsValidSeatingCapacity(seatingCapacity))
            {
                throw new InvalidOperationException("Invalid seating capacity: Must be greater than 0 & less than 10");
            } 
            else
            {
                SeatingCapacity = seatingCapacity;
            } 

            
            status = status.ToLower();

            if(status != "available" || status != "reserved" || status != "occupied")
            {
                throw new InvalidOperationException("Invalid status");
            } else
            {
                Status = status;
            }
        }

        //Methods
        
        //ChangeStatus: Change the status of the table
        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
        }

        //ReserveTable: Change the status of the table to "reserved"
        public void ReserveTable()
        {
            Status = "reserved";
        }

        //OccupyTable: Change the status of the table to "occupied"
        public void OccupyTable()
        {
            Status = "occupied";
        }

        //ClearTable: Change the status of the table to "available"
        public void ClearTable()
        {
            Status = "available";
        }

        //IsAvailable: Checks if the status of the table is "available"
        public bool IsAvailable()
        {
            return Status == "available";
        }

        //IsValidSeatingCapacity: Validation method for potential capacity input
        private static bool IsValidSeatingCapacity(int capacity)
        {
            return capacity > 0 && capacity <= 10;
        }

        //ChangeSeatingCapacity: Change the seating capacity of the table
        public void ChangeSeatingCapacity(int newCapacity)
        {
        if(!IsValidSeatingCapacity(newCapacity))
        {
            throw new InvalidOperationException("Invalid seating capacity: Must be greater than 0 & less than 10");
        }
        }
    }
}
