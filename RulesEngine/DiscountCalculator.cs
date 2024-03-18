namespace RulesEngine;

public class DiscountCalculator
{
    public decimal CalculateDiscountPercentage(Customer customer)
    {
        var ruleType = typeof(IDiscountRule);
        IEnumerable<IDiscountRule> rules = this.GetType().Assembly.GetTypes()
            .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
            .Select(r => Activator.CreateInstance(r) as IDiscountRule);

        var engine = new DiscountRuleEngine(rules.OrderBy(r => r.RuleIndex));

        return engine.CalculateDiscountPercentage(customer);
    }
}
