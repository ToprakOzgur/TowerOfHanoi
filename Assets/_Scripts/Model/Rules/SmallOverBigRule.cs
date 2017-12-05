
using System.Collections.Generic;

public class SmallOverBigRule : IRule
{
    public RuleResult Validate(List<Pin> pins)
    {
        foreach (var pin in pins)
        {
            for (int i = 0; i < pin.rings.Count - 1; i++)
            {
                if (pin.rings[i].sizeID < pin.rings[i + 1].sizeID) // below one is smaller, so return false
                    return new RuleResult(false, RuleResultIdentifiers.SmallOverBigRuleResultIdentifier);
            }
        }
        return new RuleResult(true, RuleResultIdentifiers.SmallOverBigRuleResultIdentifier);
    }
}
