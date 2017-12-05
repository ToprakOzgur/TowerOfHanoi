
using UnityEngine;
using System;
using System.Linq;

public class GameLogicController : MonoBehaviour
{
    private Game game;

    [SerializeField] RingViewGameobject[] ringViews;

    [Header("GAME/LEVEL SETTINGS ")]
    [SerializeField]
    private int pinCount;

    [SerializeField]
    private int startingPinNumber;

    [SerializeField]
    private int ringCount;

    void Start()
    {
        game = new Game(this, pinCount, startingPinNumber, ringCount);

        //Registering to  ring events (MVC controller-view comminication
        foreach (var ring in ringViews)
        {
            ring.OnRingIsOnThePinEvent += RingIsOnThePin;
        }

        //enables draggable feature of top rings at each pin
        MakesOnlyTopRingsDraggable();

    }

    public void GameWon()
    {
        //Game Win actions
        Debug.Log("GameWon");
    }

    public void TurnFailed()
    {
        //Turn Failed actions
        Debug.Log("TurnFailed");
        NextTurn();
    }

    public void TurnSuccess()
    {
        //Turn success actions
        Debug.Log("TurnSuccess");
        NextTurn();
    }

    public void NextTurn()
    {
        MakesOnlyTopRingsDraggable();
    }
    private void RingIsOnThePin(RaycastHit2D raycastResult, int ringNumber)
    {
        Debug.LogWarning(raycastResult.transform.gameObject.name);

        var ring = raycastResult.collider.gameObject.GetComponent<PinViewGameobject>();
        if (ring != null)
            game.AddRingToPin(ringNumber, ring.pinID);
        game.TurnEnded();
    }

    //enables draggable feature of top rings at each pin
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
