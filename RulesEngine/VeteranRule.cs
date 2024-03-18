namespace RulesEngine;

public class VeteranRule : IDiscountRule
{
    public int RuleIndex => 3;

    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {
        if (customer.IsVeteran)
        {
            return .10m;
        }
        return 0;
    }
}
