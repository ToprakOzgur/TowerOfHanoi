
using System.Collections.Generic;
using System.Linq;

public class Game
{
    public Logic logic;
    public Player player;//more playes can be added if game extends. when become an  online game etc...
    private GameController gameContoller;

    public Game(GameController gameContoller)
    {
        this.gameContoller = gameContoller;
        logic = new Logic();
        player = new Player();
    }

    public void TurnEnded(List<Pin> pins)
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
