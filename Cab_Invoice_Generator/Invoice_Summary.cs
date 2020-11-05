using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Invoice_Summary
    {
        Invoice_Data invoiceData;
        public Invoice_Data GetInvoice(int numberOfRides, double totalFare)
        {
            double averageFare = totalFare / numberOfRides;
            invoiceData = new Invoice_Data(numberOfRides, totalFare, averageFare);
            return invoiceData;
        }
    }
}
