using System;
using System.Collections.Generic;
using System.Text;

namespace SneakerApi.core.Services.Discounts
{
    public class PercentageDiscount: DiscountStrategy
    {
        public decimal Percentage { get; }

        public PercentageDiscount(string name, decimal percentage): base(name)
        {
            Percentage = percentage;
        }

        public override decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice * (Percentage / 100m);
        }
    }
    
}

