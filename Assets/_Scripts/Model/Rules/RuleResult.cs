public enum RuleResultIdentifiers
{
    SmallOverBigRuleResultIdentifier,
    GameWinRuleResultIdentifier
}

public class RuleResult
{
    public bool result;
    public RuleResultIdentifiers identifier;
    public RuleResult(bool result, RuleResultIdentifiers identifier)
    {
        this.result = result;
        this.identifier = identifier;
    }
}
