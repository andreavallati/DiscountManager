using DiscountManager.Interfaces;
using DiscountManager.Utilities;

namespace DiscountManager.ApplicationLayer
{
    public class RegisteredCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears)
        {
            decimal registeredCustomerDiscount = DiscountManagerUtils.RegisteredCustomerDiscount * amount;
            decimal subAmount = amount - registeredCustomerDiscount;

            return subAmount - DiscountManagerUtils.GetSubscriptionDiscount(customerSubscriptionYears) * subAmount;
        }
    }
}
