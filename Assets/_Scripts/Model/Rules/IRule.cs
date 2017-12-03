
using System.Collections.Generic;

public interface IRule
{
    RuleResult Validate(List<Pin> pins);
}
