using System;

namespace PostalService.Engine
{
    public class PostalServiceException : Exception
    {
        public PostalServiceException(string message)
            : base(message)
        {
        }
    }
}
