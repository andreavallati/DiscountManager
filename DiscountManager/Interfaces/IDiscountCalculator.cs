namespace DiscountManager.Interfaces
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(decimal amount, int customerAccountType, int customerSubscriptionYears);
    }
}
