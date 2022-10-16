using DiscountManager.Interfaces;
using DiscountManager.Utilities;

namespace DiscountManager.ApplicationLayer
{
    public class MostValuableCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            decimal mostValuableustomerDiscount = DiscountManagerUtils.MostValuableCustomerDiscount * amount;

            return amount - mostValuableustomerDiscount - DiscountManagerUtils.GetSubscriptionDiscount(customerSubscriptionYears) * (amount - mostValuableustomerDiscount);
        }
    }
}
