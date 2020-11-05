using NUnit.Framework;
using Cab_Invoice_Generator;

namespace Cab_Invoice_Generator_Program_Test
{
    public class Tests
    {
        Invoice_Generator invoiceGenerator;
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
    }
}
