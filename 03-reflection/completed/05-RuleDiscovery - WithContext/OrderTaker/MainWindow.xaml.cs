using OrderRules.RuleChecker;
using OrderTaker.Data;
using OrderTaker.SharedObjects;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OrderTaker;

public partial class MainWindow : Window
{
    OrderRuleChecker ruleChecker;
    ErrorDetails errorWindow;
    Order order;

    public MainWindow()
    {
        InitializeComponent();
        InitializeRuleChecker();

        var headerText = ConfigurationManager.AppSettings["OrderHeader"];
        if (!string.IsNullOrEmpty(headerText))
            OrderHeaderText.Text = headerText;

        CustomerComboBox.ItemsSource = People.GetPeople().OrderBy(p => p.FamilyName);
        ProductComboBox.ItemsSource = Products.GetProducts();

        ResetOrder();
    }

    private void InitializeRuleChecker()
    {
        var rulePath = ConfigurationManager.AppSettings["RelativeRulePath"];
        var applicationPath = AppDomain.CurrentDomain.BaseDirectory;

        if (string.IsNullOrEmpty(rulePath))
            rulePath = applicationPath;
        else
            rulePath = applicationPath + rulePath + Path.DirectorySeparatorChar;

        ruleChecker = new OrderRuleChecker(rulePath);
    }

    private void AddItemButton_Click(object sender, RoutedEventArgs e)
    {
        var product = ProductComboBox.SelectedItem as Product;
        var quantity = Int32.Parse(ProductQuantity.Text);

        if (product != null && quantity > 0)
        {
            var existingProduct = order.OrderItems.FirstOrDefault(p => p.ProductItem == product);

            if (existingProduct == null)
                order.OrderItems.Add(new OrderItem() { ProductItem = product, Quantity = quantity });
            else
                existingProduct.Quantity += quantity;
        }
    }

    private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var item = button.Tag as OrderItem;
        if (item != null)
        {
            order.OrderItems.Remove(item);
        }
    }

    private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        ErrorBorder.Visibility = Visibility.Hidden;
        ErrorPanel.Children.Clear();

        var result = ruleChecker.CheckRules(order);

        if (!result)
        {
            foreach (var rule in ruleChecker.BrokenRules)
            {
                var errorItem = new TextBlock();
                errorItem.Text = "o " + rule.Message;
                errorItem.Margin = new Thickness(0, 0, 0, 5);
                errorItem.TextWrapping = TextWrapping.Wrap;
                errorItem.FontWeight = FontWeights.Normal;
                errorItem.Foreground = Brushes.DarkRed;
                ErrorPanel.Children.Add(errorItem);
            }
            ErrorBorder.Visibility = Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Order Submitted");
        }
    }

    private void ResetOrder()
    {
        DataContext = null;
        order = new Order();
        order.Customer = CustomerComboBox.Items.OfType<Person>().First();
        ProductComboBox.SelectedIndex = 0;
        ProductQuantity.Text = "1";
        DataContext = order;
    }

    private void ErrorDetailsButton_Click(object sender, RoutedEventArgs e)
    {
        errorWindow = new ErrorDetails(ruleChecker.BrokenRules);
        errorWindow.Show();
    }
}
