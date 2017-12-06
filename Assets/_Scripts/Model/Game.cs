
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game
{
    private GameLogicController gameContoller;
    private List<Pin> pins = new List<Pin>();

    public Logic logic;
    public Player player;//more playes can be added if game extends. when become an  online game etc...

    public Game(GameLogicController gameContoller, int pinCount, int startingPinNumber, int ringCount) //constructor
    {
        this.gameContoller = gameContoller;
        logic = new Logic();
        player = new Player();

        var startingPinSafe = Mathf.Clamp(startingPinNumber, 1, pinCount);//clamping startingpinnumber to prevent wrong entries
        for (int i = 0; i < pinCount; i++)
        {
            pins.Add(new Pin(ringCount, i == startingPinSafe - 1)); //makes new rings and add to list,
        }

    }


    public void AddRingToPin(int ringNumber, int pinNumber)
    {
        foreach (var pin in pins)
        {
            foreach (var ring in pin.rings)
            {
                if (ring.sizeID == ringNumber) //finds the rings old pin
                {
                    pin.rings.Remove(ring); //removes ring from old pin
                    pins[pinNumber - 1].rings.Add(ring); //adds ring to new pin
                    return;
                }
            }
        }
    }

    public void CheckRules()
    {
        var results = logic.CheckRules(pins);
        RuleResultActions(results);
    }

    public void RuleResultActions(List<RuleResult> ruleResults)
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
    }

    //only top ring is draggable if pin has more than 1 ring
    public List<int> GetDraggableRings()
    {
        List<int> draggableRings = new List<int>();

        foreach (var pin in pins)
        {
            if (pin.rings.Count > 0)
            {
                var draggableRingSizeID = pin.rings[pin.rings.Count - 1].sizeID;
                draggableRings.Add(draggableRingSizeID);
            }
        }
        return draggableRings;
    }
}
