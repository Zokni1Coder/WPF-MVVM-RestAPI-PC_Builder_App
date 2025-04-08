using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Builder.Exceptions
{
    public class ConnectionErrorException : Exception
    {
        public string Descritpion;
        public ConnectionErrorException(string description)
        {
            this.Descritpion = description;
        }
    }
}
