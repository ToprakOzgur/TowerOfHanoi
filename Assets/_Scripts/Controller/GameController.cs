
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    private Game game;

    void Start()
    {
        game = new Game(this);
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
