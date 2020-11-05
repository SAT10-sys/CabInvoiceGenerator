using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Cab_Invoice_Exception:Exception
    {
        public enum ExceptionType
        {
            //storing different types of exceptions that can occur
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_USERID,
            NULL_RIDES
        }
        public ExceptionType exceptionType;
        public Cab_Invoice_Exception(ExceptionType exceptionType, string message):base(message)
        {
            //parameterized constructor
            this.exceptionType = exceptionType;
        }
    }
}
