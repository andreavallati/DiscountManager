using DiscountManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DiscountManagerUnitTests
{
    [TestClass]
    public class DiscountCalculatorTest
    {
        DiscountCalculatorService discountCalculatorService;

        [TestInitialize()]
        public void InitializeTest()
        {
            this.discountCalculatorService = new DiscountCalculatorService();
        }
        [TestMethod]
        public void GetDiscount_CustomerAccountTypeUnregistered_ReturnDiscountForUnregisteredCustomer()
        {
            decimal discount = discountCalculatorService.GetDiscount(0.5m, 1, 5);
            Assert.AreEqual(discount, 0.5m);
        }

        [TestMethod]
        public void GetDiscount_CustomerAccountTypeRegistered_ReturnDiscountForRegisteredCustomer()
        {
            decimal discount = discountCalculatorService.GetDiscount(0.5m, 2, 5);
            Assert.AreEqual(discount, 0.4275m);
        }

        [TestMethod]
        public void GetDiscount_CustomerAccountTypeValuable_ReturnDiscountForValuableCustomer()
        {
            decimal discount = discountCalculatorService.GetDiscount(0.5m, 3, 5);
            Assert.AreEqual(discount, 0.3325m);
        }

        [TestMethod]
        public void GetDiscount_CustomerAccountTypeMostValuable_ReturnDiscountForMostValuableCustomer()
        {
            decimal discount = discountCalculatorService.GetDiscount(0.5m, 4, 5);
            Assert.AreEqual(discount, 0.2375m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Amount can't be less than zero.")]
        public void GetDiscount_AmountNotHandled_ThrowException()
        {
            discountCalculatorService.GetDiscount(-0.5m, 2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Subscription years can't be less than zero.")]
        public void GetDiscount_SubscriptionYearsNotHandled_ThrowException()
        {
            discountCalculatorService.GetDiscount(0.5m, 2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Only numbers are allowed.")]
        public void CalculateDiscountClick_InputAmountNotHandled_ThrowException()
        {
            decimal amount = Convert.ToDecimal("xxx");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Only numbers are allowed.")]
        public void CalculateDiscountClick_InputTypeNotHandled_ThrowException()
        {
            int customerAccountType = Convert.ToInt32("yyy");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Only numbers are allowed.")]
        public void CalculateDiscountClick_InputYearsNotHandled_ThrowException()
        {
            int customerSubscriptionYears = Convert.ToInt32("zzz");
        }
    }
}
