using System;

namespace ApiWrapper.Helpers
{
    public static class ExceptionExctention
    {
        public static string GetaAllMessages(this Exception exp)
        {
            string message = string.Empty;
            var innerException = exp;

            do
            {
                message = message + (string.IsNullOrEmpty(innerException.Message) ? string.Empty : innerException.Message);
                innerException = innerException.InnerException;
            }
            while (innerException != null);

            return message;
        }
    };
}
