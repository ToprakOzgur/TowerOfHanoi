using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IRingState
{
    private readonly RingViewGameobject ring;

    //Constructor
    public IdleState(RingViewGameobject ringViewGameobject)
    {
        this.ring = ringViewGameobject;
    }


    public void UpdateState()
    {

    }

    public void ToDraggableState()
    {
        ring.currentState = ring.draggableState;
        ring.DraggableObject.isDRaggable = true;
    }

    public void ToReturnToOldPinState()
    {
        Debug.LogWarning("transition is not possible from IdleState to returnOldPinState. Check Again !!!");
    }

    public void ToIdleState()
    {
        Debug.Log("Already in IdleState");
    }


}
