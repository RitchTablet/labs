using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.Domain.Vehicles
{
    public record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money firtsMoney, Money secondMoney)
        {
            if (firtsMoney.Currency.Code != secondMoney.Currency.Code)
            {
                throw new Exception("The currency most need be the same type");
            }

            var totalSum = firtsMoney.Amount + secondMoney.Amount;
            return new Money(totalSum, firtsMoney.Currency);
        }

        public static Money Zero()=> new Money(0, Currency.NONE);
    }
}