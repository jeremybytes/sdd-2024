using OrderRules.Interface;
using System.Reflection;

namespace OrderRules.RuleChecker;

public class OrderRuleLoader
{
    public static List<IOrderRule> LoadRules(string assemblyPath)
    {
        List<IOrderRule> rules = new();

        if (!Directory.Exists(assemblyPath))
            return rules;

        IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(
            assemblyPath, "*.dll", SearchOption.TopDirectoryOnly);

        foreach (string assemblyFile in assemblyFiles)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyFile);

            IEnumerable<Type> ruleTypes = assembly.ExportedTypes
                .Where(rt => rt.IsClass && typeof(IOrderRule).IsAssignableFrom(rt));

            foreach (Type type in ruleTypes)
            {
                IOrderRule? rule = Activator.CreateInstance(type) as IOrderRule;
                if (rule is not null)
                    rules.Add(rule);
            }
        }

        return rules;
    }
}
