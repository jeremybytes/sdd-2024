using OrderRules.Interface;
using OrderTaker.SharedObjects;

namespace OrderRule.NameBadge;

public class NameBadgeRule : IOrderRule
{
    public string RuleName => "Name Badge Rule"; 

    public OrderRuleResult CheckRule(Order order)
    {
        var passed = true;
        var message = string.Empty;

        foreach (var item in order.OrderItems)
            if (item.ProductItem.ProductName.Contains("Name Badge") &&
                !item.ProductItem.ProductName.Contains(order.Customer.GivenName))
            {
                passed = false;
                message = $"Customer Name ({order.Customer.GivenName}) does not match Name Badge";
            }

        return new OrderRuleResult(passed, message);
    }
}
