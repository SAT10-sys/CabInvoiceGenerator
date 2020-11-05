using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Invoice_Data
    {
        public int numberOfRides;
        public double totalFare;
        public double averageFare;
        public Invoice_Data(int numberOfRides, double totalFare, double averageFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = averageFare;
        }
    }
}
