using OrderRules.Interface;

namespace OrderRules.RuleChecker;

public record BrokenRule (IOrderRule OrderRule, string Message) { }
