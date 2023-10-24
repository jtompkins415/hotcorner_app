//Public class for Reservations
using System;
using System.ComponentModel.DataAnnotations;
using MailKitSimplified.Sender.Services;
using MailKitSimplified.Sender.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotCorner.Model
{
    public class Reservation
    {
        //Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId {get; set;}
        public required int CustomerId {get; set;}
        [MaxLength(255)]
        public required string CustomerName {get; set;}
        public required string CustomerEmail {get; set;}
        public required DateTime ReservationTime {get; set;}
        public required int TableId {get; set;}
        public required int TableNumber {get; set;}
        public required string ReservationStatus {get; set;}

        private readonly ISmtpSenderFactory smtpSenderFactory;

        //Constructors & Nested Classes

        public Reservation()
        {}

        public Reservation(Customer customer, Table table, DateTime reservationTime, string status)
        {
            CustomerId = customer.CustomerId;
            CustomerName = customer.Name;
            CustomerEmail = customer.Email;
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

        public Reservation(ISmtpSenderFactory smtpSenderFactory)
        {
            this.smtpSenderFactory = smtpSenderFactory;
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

        //SendReservationConfirmationEmail: Send a confirmation email to the customer
        public void SendReservationConfirmationEmail()
        {
            SmtpSender newSender = smtpSenderFactory.CreateSmtpSender();

            var confirmationEmail = newSender.WriteEmail
                .From("hotcorneradmin@hotcornerapp.com")
                .To($"{CustomerEmail}")
                .Subject($"HotCorner! Reservation Confirmation: {ReservationId} - {ReservationTime}")
                .BodyHtml($"You reservation is confirmed!\nReservation Id:{ReservationId}\nGuest Name: {CustomerName}\nDate: {ReservationTime}")
                .SaveTemplate();
            
            confirmationEmail.Send();
        }

        //SendReservationReminderEmail: Send a reminder email to the customer
        public void SendReservationReminderEmail()
        {
            if(ReservationTime.Date == DateTime.Now)
            {
                SmtpSender newSender = smtpSenderFactory.CreateSmtpSender();

                var confirmationEmail = newSender.WriteEmail
                    .From("hotcorneradmin@hotcornerapp.com")
                    .To($"{CustomerEmail}")
                    .Subject($"HotCorner! Reservation Reminder: {ReservationId} - {ReservationTime}")
                    .BodyHtml($"This is a reminder for you reservation today!\nReservation Id:{ReservationId}\nGuest Name: {CustomerName}\nDate: {ReservationTime}")
                    .SaveTemplate();
                
                confirmationEmail.Send();
            }
        }
    }
}
