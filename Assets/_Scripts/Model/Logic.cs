
using System.Collections.Generic;

public class Logic
{
    public List<IRule> rules = new List<IRule>();

    public Logic()
    {
        rules.Add(new SmallOverBigRule());
        //rules.Add(new GameOverRule()); 
        // ...
        // ....
        // new fautures can be added to game with making new rule and add to rules list

    }
}
