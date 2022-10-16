# Discount Manager

### Project description

Calculate a discount from a customer type (unregistered, registered, valuable, most valuable) and a time of having an account in years.

### Project folders

- Application
- BusinessLogic
- Presentation
- Interfaces
- Utilities

### Project classes

- ### Application
	+ **DiscountCalculatorFactory.cs**: Implementation of the IDiscountCalculatorFactory. It returns the right class type depending on the CustomerAccountType
	+ **UnregisteredCustomerDiscountCalculator.cs**: It calculates discount for UnregisteredCustomer
	+ **RegisteredCustomerDiscountCalculator.cs**: It calculates discount for RegisteredCustomer
	+ **ValuableCustomerDiscountCalculator.cs**: It calculates discount for ValuableCustomer
	+ **MostValuableCustomerDiscountCalculator.cs**: It calculates discount for MostValuableCustomer

- ### BusinessLogic
	+ **DiscountCalculatorBusinessLogic.cs**: Core of the application. It uses Dependency Injection to inject factory interface in the constructor. It retrieves the right Discount Calculator using the factory method and calculates the discount

- ### Presentation
	+ **DiscountManagerWindow.xaml**: very basic and simple UI that gets user inputs and show the calculated discount as output.

- ### Interfaces
	+ **IDiscountCalculatorFactory.cs**: Interface implemented by the Factory class
	+ **IDiscountCalculator.cs**: Interface implemented by the available DiscountCalculator
	
- ### Models
	+ **Customer.cs**: It handles the Customer entity. It contains the enum CustomerAccountType that defines possible account types for a customer

- ### Utilities
	+ **DiscountManagerUtils.cs**: a static class with some discount constants and an utility method to get subscription discount

### Project notes
The project also includes some Unit Tests used for testing both the Factory and the single discount calculations.