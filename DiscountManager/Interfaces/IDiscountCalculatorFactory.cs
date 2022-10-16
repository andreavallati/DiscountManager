namespace DiscountManager.Interfaces
{
    public interface IDiscountCalculatorFactory
    {
        IDiscountCalculator GetDiscountCalculatorType(int customerAccountType);
    }
}
