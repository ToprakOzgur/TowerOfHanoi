
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game
{
    public Logic logic;
    public Player player;//more playes can be added if game extends. when become an  online game etc...
    private GameController gameContoller;
    private List<Pin> pins = new List<Pin>();

    public Game(GameController gameContoller, int pinCount, int startingPinNumber, int ringCount) //constructor
    {
        this.gameContoller = gameContoller;
        logic = new Logic();
        player = new Player();

        var startingPinSafe = Mathf.Clamp(startingPinNumber, 0, pinCount - 1);//clamping startingpinnumber to prevent wrong entries
        for (int i = 0; i < pinCount; i++)
        {
            pins.Add(new Pin(ringCount, i == startingPinSafe)); //makes new rings and add to list,if pin has rings at start makes variable true
        }

    }

    public void TurnEnded()
    {
        var results = logic.CheckRules(pins);
        TurnEndActions(results);
    }

    public void TurnEndActions(List<RuleResult> ruleResults)
    {
        if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.SmallOverBigRuleResultIdentifier && !x.result)) //there is SmallOverBigRule and result is false
        {
            gameContoller.TurnFailed();
            return;
        }

        if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.SmallOverBigRuleResultIdentifier && x.result))  //there is SmallOverBigRule and result is true
            gameContoller.TurnSuccess();


        if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.GameWinRuleResultIdentifier && x.result)) //there is Game Won Rule and result is true
        {
            gameContoller.GameWon();
            return;
        }

        gameContoller.NextTurn();
    }
}
