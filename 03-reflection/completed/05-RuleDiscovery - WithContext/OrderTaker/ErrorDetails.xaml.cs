using OrderRules.Interface;
using OrderRules.RuleChecker;
using System.Windows;

namespace OrderTaker;

public partial class ErrorDetails : Window
{
    private List<IOrderRule> errorList;

    public ErrorDetails(List<BrokenRule> brokenRules)
    {
        InitializeComponent();
        var errorList = brokenRules.Select(
            b => new { BrokenRule = b, TypeName = b.OrderRule.GetType().FullName, AssemblyName = b.OrderRule.GetType().Assembly.GetName().Name });
        ErrorDetailsListBox.ItemsSource = errorList;
    }
}
