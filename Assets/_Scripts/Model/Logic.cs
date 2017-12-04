
using System.Collections.Generic;

public class Logic
{
    public List<IRule> rules = new List<IRule>();

    public Logic()
    {
        rules.Add(new SmallOverBigRule());
        rules.Add(new GameWinRule());
        // ...
        // ....
        // new fautures can be added to game with making new rule and add to rules list

    }
    public List<RuleResult> CheckRules(List<Pin> pins)
    {
        List<RuleResult> ruleResults = new List<RuleResult>();

        foreach (var rule in rules)
        {
            ruleResults.Add(rule.Validate(pins));
        }
        return ruleResults;
    }
}
