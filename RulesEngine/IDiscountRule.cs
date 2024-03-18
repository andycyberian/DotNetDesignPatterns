namespace RulesEngine;

// View History
// https://github.githistory.xyz/ardalis/DesignPatternsInCSharp/blob/master/DesignPatternsInCSharp/RulesEngine/Discounts/DiscountCalculator.cs
public interface IDiscountRule
{
    int RuleIndex { get; }
    decimal CalculateDiscount(Customer customer, decimal currentDiscount);
}
