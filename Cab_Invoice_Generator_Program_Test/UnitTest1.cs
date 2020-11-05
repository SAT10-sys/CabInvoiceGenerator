using NUnit.Framework;
using System.Collections.Generic;
using Cab_Invoice_Generator;

namespace Cab_Invoice_Generator_Program_Test
{
    public class Tests
    {
        Invoice_Generator invoiceGenerator;
        List<Ride> listOfRides;

        [SetUp]
        public void SetUp()
        {
            invoiceGenerator = new Invoice_Generator();
        }
        [Test]
        public void TestMethod1()
        {
            double distance = 5; //in km
            int time = 20;   //in minutes
            double fare = invoiceGenerator.CalculateFare(new Ride(distance, time));
            Assert.AreEqual(70, fare);
        }
        [Test]
        public void TestMethod2()
        {
            double distance = -5; //in km
            int time = 20;   //in minute
            var exception = Assert.Throws<Cab_Invoice_Exception>(() => invoiceGenerator.CalculateFare(new Ride(distance, time)));
            Assert.AreEqual(Cab_Invoice_Exception.ExceptionType.INVALID_DISTANCE, exception.exceptionType);
        }
        [Test]
        public void TestMethod3()
        {
            double distance = 5; //in km
            int time = -20;   //in minute
            var exception = Assert.Throws<Cab_Invoice_Exception>(() => invoiceGenerator.CalculateFare(new Ride(distance, time)));
            Assert.AreEqual(Cab_Invoice_Exception.ExceptionType.INVALID_TIME, exception.exceptionType);
        }
        [Test]
        public void TestMethod4()
        {
            listOfRides = new List<Ride> { new Ride(5, 20), new Ride(3, 15), new Ride(2, 10) };
            double fare = invoiceGenerator.FareOfMultipleRides(listOfRides);
            Assert.AreEqual(145, fare);
        }
        [Test]
        public void TestMethod5()
        {
            listOfRides = new List<Ride> { new Ride(5, 20), new Ride(3, 15), new Ride(2, 10) };
            var exception = Assert.Throws<Cab_Invoice_Exception>(() => invoiceGenerator.FareOfMultipleRides(listOfRides));
            Assert.AreEqual(Cab_Invoice_Exception.ExceptionType.NULL_RIDES, exception.exceptionType);
        }
    }
}
