using DiscountManager.Services;
using System;
using System.Windows;

namespace DiscountManager.PresentationLayer
{
    /// <summary>
    /// Interaction logic for DiscountManagerWindow.xaml
    /// </summary>
    public partial class DiscountManagerWindow : Window
    {
        DiscountCalculatorService _discountCalculatorService;

        public DiscountManagerWindow()
        {
            InitializeComponent();

            _discountCalculatorService = new DiscountCalculatorService();
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

                    if (_discountCalculatorService != null)
                    {
                        decimal discount = _discountCalculatorService.GetDiscount(amount, customerAccountType, customerSubscriptionYears);

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
            Application.Current.Shutdown();
        }
    }
}
