using DiscountManager.Interfaces;

namespace DiscountManager.BusinessLogicLayer
{
    public class DiscountCalculatorBusinessLogic
    {
        private readonly IDiscountCalculatorFactory _discountCalculatorFactory;

        public DiscountCalculatorBusinessLogic(IDiscountCalculatorFactory discountCalculatorFactory)
        {
            _discountCalculatorFactory = discountCalculatorFactory;
        }

        public decimal ProcessDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            return _discountCalculatorFactory.GetDiscountCalculatorType(customerAccountType).CalculateDiscount(amount, customerAccountType, customerSubscriptionYears);
        }
    }
}
