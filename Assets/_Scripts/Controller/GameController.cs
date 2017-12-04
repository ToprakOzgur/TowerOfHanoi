
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    private Game game;

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
}
