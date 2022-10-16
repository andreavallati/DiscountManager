namespace DiscountManager.Utilities
{
    public static class DiscountManagerUtils
    {
        private const decimal REGISTERED_CUSTOMER_DISCOUNT = 0.1m;
        private const decimal VALUABLE_CUSTOMER_DISCOUNT = 0.7m;
        private const decimal MOST_VALUABLE_CUSTOMER_DISCOUNT = 0.5m;

        private const int MAX_SUBSCRIPTION_YEARS = 5;

        public static decimal RegisteredCustomerDiscount { get { return REGISTERED_CUSTOMER_DISCOUNT; } }
        public static decimal ValuableCustomerDiscount { get { return VALUABLE_CUSTOMER_DISCOUNT; } }
        public static decimal MostValuableCustomerDiscount { get { return MOST_VALUABLE_CUSTOMER_DISCOUNT; } }

        public static decimal GetSubscriptionDiscount(int customerSubscriptionYears)
        {
            return (customerSubscriptionYears > MAX_SUBSCRIPTION_YEARS) ? (decimal)MAX_SUBSCRIPTION_YEARS / 100 : (decimal)customerSubscriptionYears / 100;
        }
    }
}
