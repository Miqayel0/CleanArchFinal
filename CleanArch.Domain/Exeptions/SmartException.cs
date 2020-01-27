using System;

namespace CleanArch.Domain.Exeptions
{
    public class SmartException : ApplicationException
    {
        public SmartException(string message = "Smart Eception was thrown") : base(message)
        {
        }
    }
}
