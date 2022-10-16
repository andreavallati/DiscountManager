using DiscountManager.ApplicationLayer;
using DiscountManager.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DiscountManagerUnitTests
{
    [TestClass]
    public class DiscountCalculatorFactoryTest
    {
        DiscountCalculatorFactory discountCalculatorFactory;

        [TestInitialize()]
        public void InitializeTest()
        {
            this.discountCalculatorFactory = new DiscountCalculatorFactory();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Customer account type not handled.")]
        public void GetDiscountCalculatorType_CustomerAccountTypeNotHandled_ThrowException()
        {
            discountCalculatorFactory.GetDiscountCalculatorType(0);
        }

        [TestMethod]
        public void GetDiscountCalculatorType_CustomerAccountTypeUnregistered_ReturnTypeOfUnregisteredCustomer()
        {
            IDiscountCalculator unregisteredCustomer = discountCalculatorFactory.GetDiscountCalculatorType(1);
            Assert.IsInstanceOfType(unregisteredCustomer, typeof(UnregisteredCustomerDiscountCalculator));
        }

        [TestMethod]
        public void GetDiscountCalculatorType_CustomerAccountTypeRegistered_ReturnTypeOfRegisteredCustomer()
        {
            IDiscountCalculator registeredCustomer = discountCalculatorFactory.GetDiscountCalculatorType(2);
            Assert.IsInstanceOfType(registeredCustomer, typeof(RegisteredCustomerDiscountCalculator));
        }

        [TestMethod]
        public void GetDiscountCalculatorType_CustomerAccountTypeValuable_ReturnTypeOfValuableCustomer()
        {
            IDiscountCalculator valuableCustomer = discountCalculatorFactory.GetDiscountCalculatorType(3);
            Assert.IsInstanceOfType(valuableCustomer, typeof(ValuableCustomerDiscountCalculator));
        }

        [TestMethod]
        public void GetDiscountCalculatorType_CustomerAccountTypeMostValuable_ReturnTypeOfMostValuableCustomer()
        {
            IDiscountCalculator mostValuableCustomer = discountCalculatorFactory.GetDiscountCalculatorType(4);
            Assert.IsInstanceOfType(mostValuableCustomer, typeof(MostValuableCustomerDiscountCalculator));
        }
    }
}
