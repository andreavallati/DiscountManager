using DiscountManager.Interfaces;

namespace DiscountManager.ApplicationLayer
{
    public class UnregisteredCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            return amount;
        }
    }
}
