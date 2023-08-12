using System;

namespace RestaurantAPI_5._0.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        { 
        }
    }
}
