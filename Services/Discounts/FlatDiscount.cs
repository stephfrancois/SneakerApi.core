using System;
using System.Collections.Generic;
using System.Text;

namespace SneakerApi.core.Services.Discounts
{
    public class FlatDiscount: DiscountStrategy
    {
        public decimal Amount { get; }

        public FlatDiscount(string name, decimal amount):base(name)
        {
            Amount = amount;
        }

        public override decimal CalculateDiscount(decimal originalPrice)
        {
            return Amount;
        }   
    }
}
