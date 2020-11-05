using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Ride
    {
        public enum RideType
        {
            NORMAL,
            PREMIUM
        }
        public double distance;
        public int time;
        public Ride()
        {
            // default constructor
            distance = 0.0;
            time = 0;
        }
        public Ride(double distance, int time)
        {
            //parameterized constructor
            this.distance = distance;
            this.time = time;
        }
    }
}
