//Public class for Customers
using System;
using System.ComponentModel.DataAnnotations;
using MailKitSimplified.Sender.Services;

namespace HotCorner.Model
{
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

        public List<Reservation> UpcomingReservations {get; set;}

        private readonly ISmtpSenderFactory smtpSenderFactory;


        //Constructors
        public Customer()
        {
            UpcomingReservations = new List<Reservation>();
        }

        public Customer(string name, string email, int loyaltyPoints, List<Reservation> reservations)
        {
            Name = name;
            Email = email;
            LoyaltyPoints = loyaltyPoints;
            UpcomingReservations.AddRange(reservations);
        }

        public Customer(ISmtpSenderFactory smtpSenderFactory)
        {
            this.smtpSenderFactory = smtpSenderFactory;
        }

        //Methods

        //AddLoyaltyPoints: Add loyalty points to a customer account
        public void AddLoyaltyPoints(int pointsToAdd)
        {
            LoyaltyPoints += pointsToAdd;
        }

        //RemoveLoyaltyPoints: Remove loyalty points from a customer account
        public void RemoveLoyaltyPoints(int pointsToRemove)
        {
            LoyaltyPoints -= pointsToRemove;
        }

        //MakeReservation: Add a reservation to a customer's account
        public void MakeReservation(Reservation reservation)
        {
            UpcomingReservations.Add(reservation);
        }

        //CancelReservation: Remove a reservation from a customer's account
        public void CancelReservation(Guid reservationId)
        {
            var reservation = UpcomingReservations.FirstOrDefault(r => r.ReservationId == reservationId);
            if (reservation != null)
            {
                UpcomingReservations.Remove(reservation);
            }
        }

        //UpdateEmail: Update a customer's email address
        public void UpdateEmail(string newEmail)
        {
            Email = newEmail;
        }

        //GetUpcomingReservations: Retrieve a list of upcoming reservation
        public List<Reservation> GetUpcomingReservations()
        {
            return UpcomingReservations;
        }

        //GetLoyaltyPoints: Retrieve the customer's current loyalty point balance
        public int GetLoyaltyPoints()
        {
            return LoyaltyPoints;
        }

        //SendLoyaltyPointsNotification: Notify the customer about their loyalty points balance
        public void SendLoyaltyPointsNotification()
        {
            SmtpSender newSender = smtpSenderFactory.CreateSmtpSender();

            var confirmationEmail = newSender.WriteEmail
                .From("hotcorneradmin@hotcornerapp.com")
                .To($"{Email}")
                .Subject($"HotCorner! {Name}'s Loyalty Points Balance")
                .BodyHtml($"Your current HotCorner! points balance is {LoyaltyPoints}")
                .SaveTemplate();
            
            confirmationEmail.Send();
        }
    }
}
