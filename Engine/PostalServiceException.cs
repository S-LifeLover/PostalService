using System;

namespace PostalService.Engine
{
    class PostalServiceException : Exception
    {
        public PostalServiceException(string message)
            : base(message)
        {
        }
    }
}
