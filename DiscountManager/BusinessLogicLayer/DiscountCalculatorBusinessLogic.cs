using DiscountManager.Interfaces;
using System;

namespace DiscountManager.BusinessLogicLayer
{
    public class DiscountCalculatorBusinessLogic
    {
        private readonly IDiscountCalculator _discountCalculator;

        public DiscountCalculatorBusinessLogic(IDiscountCalculatorFactory discountCalculatorFactory, int customerAccountType)
        {
            _discountCalculator = discountCalculatorFactory.GetDiscountCalculatorType(customerAccountType);
        }

        public decimal GetCalculatedDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            if (amount < 0)
                throw new Exception("Amount can't be negative.");

            if (customerSubscriptionYears < 0)
                throw new Exception("Subscription years can't be negative.");

            return _discountCalculator.CalculateDiscount(amount, customerAccountType, customerSubscriptionYears);
        }
    }
}
