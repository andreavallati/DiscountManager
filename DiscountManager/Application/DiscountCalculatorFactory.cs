using DiscountManager.Interfaces;
using System;

namespace DiscountManager.ApplicationLayer
{
    public class DiscountCalculatorFactory : IDiscountCalculatorFactory
    {
        public IDiscountCalculator GetDiscountCalculatorType(int customerAccountType)
        {
            switch ((CustomerAccountType)customerAccountType)
            {
                case CustomerAccountType.UnregisteredCustomer:
                    return new UnregisteredCustomerDiscountCalculator();
                case CustomerAccountType.RegisteredCustomer:
                    return new RegisteredCustomerDiscountCalculator();
                case CustomerAccountType.ValuableCustomer:
                    return new ValuableCustomerDiscountCalculator();
                case CustomerAccountType.MostValuableCustomer:
                    return new MostValuableCustomerDiscountCalculator();
                default:
                    throw new Exception("Customer account type not handled.");
            }
        }
    }
}
