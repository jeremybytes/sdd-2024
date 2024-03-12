using OrderRules.Interface;
using OrderTaker.SharedObjects;

namespace OrderRule.Quantity;

public class MaxStarshipRule : IOrderRule
{
    public string RuleName => "Maximum Starship Rule";

    public OrderRuleResult CheckRule(Order order)
    {
        var passed = true;
        var message = string.Empty;

        foreach (var item in order.OrderItems)
            if (item.ProductItem.ProductName == "Starship" &&
                item.Quantity > 1)
            {
                passed = false;
                message = "Maximum of 1 Starship per order";
            }
        return new OrderRuleResult(passed, message);
    }
}
