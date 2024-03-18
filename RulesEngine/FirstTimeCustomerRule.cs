namespace RulesEngine;

public class FirstTimeCustomerRule : IDiscountRule
{
    public int RuleIndex => 1;

    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {
        if (!customer.DateOfFirstPurchase.HasValue)
        {
            return .15m;
        }
        return 0;
    }
}
