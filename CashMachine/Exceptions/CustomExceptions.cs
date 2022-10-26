using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Exceptions
{

    public class BalanceLessThanRequestedAmountException : Exception
    {
        public BalanceLessThanRequestedAmountException(string message) : base(message)
        {
        }
    }

    public class BanknoteIsNotSupportedException : NotSupportedException
    {
        public BanknoteIsNotSupportedException(string message) : base(message)
        {
        }
    }
    
}
