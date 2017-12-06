
using UnityEngine;
using System;
using System.Linq;

public class GameLogicController : MonoBehaviour
{
    private Game game;

    [SerializeField] RingViewGameobject[] ringViews;
    [SerializeField] Transform[] pinPositions;
    [SerializeField] GameObject gameWinText;

    private int pinCount = 3;
    private int startingPinNumber = 1;
    private int ringCount = 4;

    void Start()
    {
        game = new Game(this, pinCount, startingPinNumber, ringCount);

        //Registering to  ring events (MVC controller-To-View comminication)
        foreach (var ring in ringViews)
        {
            ring.OnRingIsOnThePinEvent += RingIsOnThePin;
        }
    }

    public void GameWon()
    {
        Debug.Log("GameWon");
        gameWinText.SetActive(true);
    }

    private int lastPlayedRingNumber;

    public void TurnFailed()
    {
        Debug.Log("TurnFailed");

        var ring = ringViews.First(x => x.ringNumber == lastPlayedRingNumber); // finds the failed ring
        game.AddRingToPin(lastPlayedRingNumber, ring.currenPin); //put the failed ring to old pin at Model

        ring.returnToOldPinState.oldPinTopPosition = pinPositions[ring.currenPin - 1]; //assign falied ring  where to go back
        ring.currentState = ring.returnToOldPinState; //change failed rings state to go back 

    }

    private int lastPlayedPinNumber;

    public void TurnSuccess()
    {
        Debug.Log("TurnSuccess");
        var ring = ringViews.First(x => x.ringNumber == lastPlayedRingNumber); //gets the succesfully moved ring
        ring.currenPin = lastPlayedPinNumber; //updates  the moved rings curren Pin
        MakesOnlyTopRingsDraggable();// makes the top rings draggable
    }

    private void RingIsOnThePin(RaycastHit2D raycastResult, int ringNumber)
    {
        lastPlayedRingNumber = ringNumber;
        var pin = raycastResult.collider.gameObject.GetComponent<PinViewGameobject>();

        if (pin != null)
            game.AddRingToPin(ringNumber, pin.pinID);
        lastPlayedPinNumber = pin.pinID;

        game.CheckRules();
    }

    //enables draggable feature of the top rings at each pin
    private void MakesOnlyTopRingsDraggable()
    {
        var draggableRings = game.GetDraggableRings();

        foreach (var ring in ringViews)
        {
            ring.currentState = ring.idleState;
        }

        foreach (var number in draggableRings)
        {
            var ring = ringViews.First(x => x.ringNumber == number);
            ring.currentState = ring.draggableState;

        }
    }

}


