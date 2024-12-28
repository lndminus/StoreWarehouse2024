using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Infrastructure
{
    public class BLException : Exception
    {
        public string ExceptionProperty { get; protected set; }
        public BLException(string message, string property) : base(message)
        {
            this.ExceptionProperty = property;
        }
    }
}
