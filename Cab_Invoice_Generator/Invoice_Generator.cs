using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Invoice_Generator
    {
        readonly int COST_PER_KM = 10;
        readonly int COST_PER_MIN = 1;
        readonly int MIN_FARE = 5;
        double totalFare;
        RideType rideType;
        Invoice_Summary invoiceSummary = new Invoice_Summary();
        Ride_Repository rideRepository = new Ride_Repository();
        public Invoice_Generator()
        { } // default constructor
        public double CalculateFare(Ride ride)
        {
            if (ride == null)
                throw new Cab_Invoice_Exception(Cab_Invoice_Exception.ExceptionType.NULL_RIDES, "Null Ride"); // throwing null ride exception
            if (ride.distance <= 0)
                throw new Cab_Invoice_Exception(Cab_Invoice_Exception.ExceptionType.INVALID_DISTANCE, "Distance is invalid"); // throwing invalid distance exception
            if (ride.time <= 0)
                throw new Cab_Invoice_Exception(Cab_Invoice_Exception.ExceptionType.INVALID_TIME, "Time is invalid"); // throwing invalid time exception
            double fare = (ride.distance * COST_PER_KM) + (ride.time * COST_PER_MIN);
            return Math.Max(fare, MIN_FARE); // if calculated fare is lesser than minimum fare, returns minimum fare
        }
        public double FareOfMultipleRides(List<Ride> listOfRides)
        {
            // method to calculate fare of multiple rides
            this.totalFare = 0;
            foreach (var ride in listOfRides)
                this.totalFare = totalFare + CalculateFare(ride);
            return this.totalFare;
        }
        public Invoice_Data GetSummary(List<Ride> listOfRides)
        {
            double fare = FareOfMultipleRides(listOfRides);
            Invoice_Data invoiceData = invoiceSummary.GetInvoice(listOfRides.Count, totalFare);
            return invoiceData;
        }
        public void AddRideDetails(int userId, List<Ride> listOfRides)
        {
            rideRepository.Add(userId, listOfRides);
        }
        public Invoice_Data GetInvoice(int userId)
        {
            List<Ride> listOfRides = rideRepository.GetRides(userId);
            Invoice_Data invoiceData = GetSummary(listOfRides);
            return invoiceData;
        }
        public Invoice_Generator(RideType rideType)
        {
            this.rideType = rideType;
            if (rideType.Equals(RideType.NORMAL))
            {
                this.COST_PER_KM = 10;
                this.COST_PER_MIN = 1;
                this.MIN_FARE = 5;
            }
            else if (rideType.Equals(RideType.PREMIUM))
            {
                this.COST_PER_KM = 15;
                this.COST_PER_MIN = 2;
                this.MIN_FARE = 20;
            }
            else            
                throw new Cab_Invoice_Exception(Cab_Invoice_Exception.ExceptionType.INVALID_RIDE_TYPE, "Ride type is Invalid");            
        }
    }
}
