
using System.Collections.Generic;

public class GameOverRule : IRule
{
    public RuleResult Validate(List<Pin> pins)
    {
        foreach (var pin in pins)
        {
            if (pin.rings.Count != pin.maxRingCount) //pin does not have all the rings.Return false
                return new RuleResult(false);

            for (int i = 0; i < pin.rings.Count - 1; i++) //not all the rings sorted .Return false
            {
                if (pin.rings[i].sizeID < pin.rings[i + 1].sizeID)
                    return new RuleResult(false);
            }

            if (pin.isStartingPin)  // if its starting pin retun false  ()
                return new RuleResult(false);
        }

        return new RuleResult(true); //passed all conditions. So returns true
    }
}