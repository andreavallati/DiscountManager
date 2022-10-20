using DiscountManager.ApplicationLayer;
using DiscountManager.BusinessLogicLayer;
using System;

namespace DiscountManager.Services
{
    public class DiscountCalculatorService
    {
        DiscountCalculatorBusinessLogic _discountCalculatorBusinessLogic;

        public DiscountCalculatorService()
        {
            //Dependency Injection by constructor
            _discountCalculatorBusinessLogic = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory());
        }

        public decimal GetDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            if (amount < 0)
                throw new Exception("Amount can't be less than zero.");

            if (customerSubscriptionYears < 0)
                throw new Exception("Subscription years can't be less than zero.");

            return _discountCalculatorBusinessLogic.ProcessDiscount(amount, customerAccountType, customerSubscriptionYears);
        }
    }
}
