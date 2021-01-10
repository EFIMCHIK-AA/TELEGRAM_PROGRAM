using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELEGRAM_INVITER.Exceptions
{
    public class StopWorkException : Exception
    {
        public StopWorkException(string message): base(message) { }
    }
}
