using CashMachine.Exceptions;
using System;
using System.Collections.Generic;

namespace CashMachine
{
    public class CashMachine : ICashMachine
    {
        private int _currentAmount;
        private readonly List<int> _availableBanknotes = new List<int>() {5, 10, 20, 50, 100};

        public int WithDraw(int amount)
        {
            if (IsAbleToWithdraw(amount) && ISValidAmount(amount))
            {
                _currentAmount -= amount;
                return amount;
            }
            throw new BalanceLessThanRequestedAmountException($"Your balance is less then requested {amount} for withdrawn");
        }

        public void Insert(int[] cash)
        {
            foreach (var banknote in cash)
            {
                if (IsSupportedBanknote(banknote))
                {
                    _currentAmount += banknote;
                }
                else
                {
                    throw new BanknoteIsNotSupportedException($"{banknote} is Not Supported");
                }
            }
        }

        private bool IsSupportedBanknote(int banknote)
        {
            return _availableBanknotes.Contains(banknote);
        }

        private bool IsAbleToWithdraw(int amount)
        {
            return _currentAmount > amount;
        }

        private bool ISValidAmount(int amount)
        {
            if(amount % 5 == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}