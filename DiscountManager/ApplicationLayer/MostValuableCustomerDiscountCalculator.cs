using DiscountManager.Interfaces;
using DiscountManager.Utilities;

namespace DiscountManager.ApplicationLayer
{
    public class MostValuableCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            decimal mostValuableCustomerDiscount = DiscountManagerUtils.MostValuableCustomerDiscount * amount;
            decimal subAmount = amount - mostValuableCustomerDiscount;

            return subAmount - DiscountManagerUtils.GetSubscriptionDiscount(customerSubscriptionYears) * subAmount;
        }
    }
}
