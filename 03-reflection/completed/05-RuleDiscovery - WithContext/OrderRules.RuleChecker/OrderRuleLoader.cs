using OrderRules.Interface;
using System.Reflection;

namespace OrderRules.RuleChecker;

public class OrderRuleLoader
{
    public static List<IOrderRule> LoadRules(string assemblyPath)
    {
        var rules = new List<IOrderRule>();

        if (!Directory.Exists(assemblyPath))
            return rules;

        IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(
            assemblyPath, "*.dll", SearchOption.TopDirectoryOnly);

        foreach (string assemblyFile in assemblyFiles)
        {
            RuleLoadContext loadContext = new RuleLoadContext(assemblyFile);
            AssemblyName assemblyName = new AssemblyName(Path.GetFileNameWithoutExtension(assemblyFile));
            Assembly ruleAssembly = loadContext.LoadFromAssemblyName(assemblyName);

            var ruleTypes = ruleAssembly.ExportedTypes
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
