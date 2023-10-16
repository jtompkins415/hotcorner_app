//Public class for Reservations

using System;
using System.ComponentModel.DataAnnotations;
using MailKitSimplified.Sender.Services;

public class Reservation
{
    //Properties

    [Key]
    public Guid ReservationId {get; set;}
    public required Guid CustomerId {get; set;}
    [MaxLength(255)]
    public required string CustomerName {get; set;}
    public required DateTime ReservationTime {get; set;}
    public required Guid TableId {get; set;}
    public required int TableNumber {get; set;}
    public required string ReservationStatus {get; set;}

    //Constructors & Nested Classes

    public Reservation()
    {}

    public Reservation(Customer customer, Table table, DateTime reservationTime, string status)
    {
        ReservationId = Guid.NewGuid();
        CustomerId = customer.CustomerId;
        CustomerName = customer.Name;
        ReservationTime = reservationTime;
        TableId = table.TableId;
        TableNumber = table.TableNumber;
        
        if(!IsValidReservationStatus(status))
        {
            throw new InvalidOperationException("Invalid Reservation Status");
        }
        else
        {
            ReservationStatus = status;
        }

    }
    //ReserverationDetails: Class that holds details of a specific reservation
    public class ReservationDetails
    {
        public required string CustomerName {get; set;}
        public int TableNumber {get; set;}
        public DateTime ReservationTime {get; set;}
        public required string ReservationStatus {get; set;}
    }

    //Methods

    //IsValidReservationStatus: Validation method for reservation status
    private static bool IsValidReservationStatus(string status)
    {
        status = status.ToLower();
        return status == "confirmed" || status == "canceled" || status == "finished";
    }

    //CancelReservation: Set Reservation status to "canceled"
    public void CancelReservation()
    {
        ReservationStatus = "canceled";
    }

    //RescheduleReservation: Set reservation time to a future date/time
    public void RescheduleReservation(DateTime newReservationTime)
    {
        DateTime currentDateTime = DateTime.Now;

        if(newReservationTime < currentDateTime)
        {
            throw new InvalidOperationException("New reservation cannot be before current date & time");
        }

        ReservationTime = newReservationTime;
    }

    //GetReservationDetails: Return details about the reservation
    public ReservationDetails GetReservationDetails()
    {
        return new ReservationDetails
        {
            CustomerName = CustomerName,
            TableNumber = TableNumber,
            ReservationTime = ReservationTime,
            ReservationStatus = ReservationStatus
        };
    }

    //IsUpcoming: Checks if the reservation is upcoming
    public bool IsUpcoming()
    {
        return ReservationTime > DateTime.Now;
    }

    //IsPast: Checks if the reservation has passed
    public bool IsPast()
    {
        return ReservationTime < DateTime.Now;
    }

    //IsToday: Check is the reservation is today
    public bool IsToday()
    {
        return ReservationTime.Date == DateTime.Now.Date;
    }

    //SendConfirmationEmail: Send a confirmation email to the customer
}