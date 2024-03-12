using OrderTaker.SharedObjects;

namespace OrderRules.Interface;

public interface IOrderRule
{
    string RuleName { get; }
    OrderRuleResult CheckRule(Order order);
}

public record OrderRuleResult(bool Result, string Message) { }

