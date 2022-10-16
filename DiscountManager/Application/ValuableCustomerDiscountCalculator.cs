using DiscountManager.Interfaces;
using DiscountManager.Utilities;

namespace DiscountManager.ApplicationLayer
{
    public class ValuableCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            decimal valuableCustomerDiscount = DiscountManagerUtils.ValuableCustomerDiscount * amount;

            return valuableCustomerDiscount - DiscountManagerUtils.GetSubscriptionDiscount(customerSubscriptionYears) * valuableCustomerDiscount;
        }
    }
}
