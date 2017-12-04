
using UnityEngine;
using System;

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
    }

    public void GameWon()
    {
        //Game Win actions

    }

    public void TurnFailed()
    {
        //Turn Failed actions
    }

    public void TurnSuccess()
    {
        //Turn success actions
    }

    public void NextTurn()
    {

    }
    private void RingIsOnThePin(RaycastHit2D raycastResult, int ringNumber)
    {
        Debug.Log(raycastResult.transform.gameObject.name);

        var ring = raycastResult.collider.gameObject.GetComponent<PinViewGameobject>();
        if (ring != null)
            game.AddRingToPin(ringNumber, ring.pinID);
    }


}
