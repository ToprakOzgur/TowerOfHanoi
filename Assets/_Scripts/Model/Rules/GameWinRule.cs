
using System.Collections.Generic;

public class GameWinRule : IRule
{
    public RuleResult Validate(List<Pin> pins)
    {

        foreach (var pin in pins)
        {
            if (pin.isStartingPin)  // if its starting pin continue to check next pin
                continue;

            if (pin.rings.Count != pin.maxRingCount) //pin does not have all the rings , continue to check next pin
                continue;

            for (int i = 0; i < pin.rings.Count - 1; i++) //rings not sorted ,continue to check next pin
            {
                if (pin.rings[i].sizeID < pin.rings[i + 1].sizeID)
                    continue;
            }

            return new RuleResult(true, RuleResultIdentifiers.GameWinRuleResultIdentifier); //passed all conditions.  returns true
        }
        return new RuleResult(false, RuleResultIdentifiers.GameWinRuleResultIdentifier); //failed all conditions.  returns true

    }
}