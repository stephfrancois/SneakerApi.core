using System;
using System.Collections.Generic;
using System.Text;

namespace SneakerApi.core.Services.Discounts
{
    public abstract class DiscountStrategy
    {
        public string Name { get;}

        protected DiscountStrategy(string name)
        {
            Name = name;
        }

        public abstract decimal CalculateDiscount(decimal originalPrice );
    }
}
