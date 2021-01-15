using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELEGRAM_SPAMER.Exceptions
{
    public class StopWorkException : Exception
    {
        public StopWorkException(string message) : base(message) { }
    }
}
