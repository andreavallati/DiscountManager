using DiscountManager.Interfaces;
using DiscountManager.Utilities;

namespace DiscountManager.ApplicationLayer
{
    public class MostValuableCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            decimal mostValuableCustomerDiscount = DiscountManagerUtils.MostValuableCustomerDiscount * amount;

            return amount - mostValuableCustomerDiscount - DiscountManagerUtils.GetSubscriptionDiscount(customerSubscriptionYears) * (amount - mostValuableCustomerDiscount);
        }
    }
}
