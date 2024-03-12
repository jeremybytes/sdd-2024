using OrderRules.Interface;
using OrderTaker.SharedObjects;

namespace OrderRule.Quantity;

public class OneCaptainChairRule : IOrderRule
{
    public string RuleName => "One Captain Chair Rule";

    public OrderRuleResult CheckRule(Order order)
    {
        var chairCount = 0;
        var passed = true;
        var message = string.Empty;

        foreach (var item in order.OrderItems)
            if (item.ProductItem.ProductName.Contains("Captain") &&
                item.ProductItem.ProductName.Contains("Chair"))
            {
                chairCount += item.Quantity;
            }

        if (chairCount > 1)
        {
            passed = false;
            message = "Only 1 Captain Chair per order";
        }
        return new OrderRuleResult(passed, message);
    }

}
