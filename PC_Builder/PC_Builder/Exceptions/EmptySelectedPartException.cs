using System;

namespace PC_Builder.Exceptions
{
    public class EmptySelectedPartException : Exception
    {
        public string Message;
        public EmptySelectedPartException(string part)
        {
            this.Message += $"No component selected! Please select a {part} before proceeding.";
        }
    }
}
