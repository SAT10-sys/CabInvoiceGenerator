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
    }
}
