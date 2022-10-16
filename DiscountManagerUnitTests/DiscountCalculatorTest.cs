using DiscountManager.ApplicationLayer;
using DiscountManager.BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DiscountManagerUnitTests
{
    [TestClass]
    public class DiscountCalculatorTest
    {
        [TestMethod]
        public void GetCalculatedDiscount_CustomerAccountTypeUnregistered_ReturnDiscountForUnregisteredCustomer()
        {
            DiscountCalculatorBusinessLogic unregisteredCustomer = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), 1);
            decimal discount = unregisteredCustomer.GetCalculatedDiscount(0.5m, 1, 5);
            Assert.AreEqual(discount, 0.5m);
        }

        [TestMethod]
        public void GetCalculatedDiscount_CustomerAccountTypeRegistered_ReturnDiscountForRegisteredCustomer()
        {
            DiscountCalculatorBusinessLogic registeredCustomer = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), 2);
            decimal discount = registeredCustomer.GetCalculatedDiscount(0.5m, 2, 5);
            Assert.AreEqual(discount, 0.4275m);
        }

        [TestMethod]
        public void GetCalculatedDiscount_CustomerAccountTypeValuable_ReturnDiscountForValuableCustomer()
        {
            DiscountCalculatorBusinessLogic valuableCustomer = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), 3);
            decimal discount = valuableCustomer.GetCalculatedDiscount(0.5m, 3, 5);
            Assert.AreEqual(discount, 0.3325m);
        }

        [TestMethod]
        public void GetCalculatedDiscount_CustomerAccountTypeMostValuable_ReturnDiscountForMostValuableCustomer()
        {
            DiscountCalculatorBusinessLogic mostValuableCustomer = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), 4);
            decimal discount = mostValuableCustomer.GetCalculatedDiscount(0.5m, 4, 5);
            Assert.AreEqual(discount, 0.2375m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Amount can't be negative.")]
        public void GetCalculatedDiscount_AmountNotHandled_ThrowException()
        {
            DiscountCalculatorBusinessLogic registeredCustomer = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), 2);
            registeredCustomer.GetCalculatedDiscount(-0.5m, 2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Subscription years can't be negative.")]
        public void GetCalculatedDiscount_SubscriptionYearsNotHandled_ThrowException()
        {
            DiscountCalculatorBusinessLogic registeredCustomer = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), 2);
            registeredCustomer.GetCalculatedDiscount(0.5m, 2, -5);
        }
    }
}
