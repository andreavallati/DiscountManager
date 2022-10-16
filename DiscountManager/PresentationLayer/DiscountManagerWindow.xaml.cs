using DiscountManager.ApplicationLayer;
using DiscountManager.BusinessLogicLayer;
using System;
using System.Windows;

namespace DiscountManager.PresentationLayer
{
    /// <summary>
    /// Interaction logic for DiscountManagerWindow.xaml
    /// </summary>
    public partial class DiscountManagerWindow : Window
    {
        public DiscountManagerWindow()
        {
            InitializeComponent();
        }

        private void CalculateDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrEmpty(typeTextBox.Text) && !string.IsNullOrEmpty(yearsTextBox.Text))
            {
                try
                {
                    decimal amount = Convert.ToDecimal(amountTextBox.Text);
                    int customerAccountType = Convert.ToInt32(typeTextBox.Text);
                    int customerSubscriptionYears = Convert.ToInt32(yearsTextBox.Text);

                    DiscountCalculatorBusinessLogic discountCalculator = new DiscountCalculatorBusinessLogic(new DiscountCalculatorFactory(), customerAccountType);

                    if (discountCalculator != null)
                    {
                        decimal discount = discountCalculator.GetCalculatedDiscount(amount, customerAccountType, customerSubscriptionYears);

                        outputTextBox.Text = "Calculated discount is: " + discount;
                    }
                }
                catch(FormatException)
                {
                    outputTextBox.Text = "Only numbers are allowed.";
                }
                catch(Exception ex)
                {
                    outputTextBox.Text = ex.Message;
                }
            }
            else
            {
                outputTextBox.Text = "Wrong use. All fields must be filled.";
            }
        }

        private void CloseApplication_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
