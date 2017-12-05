using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOldPinState : IRingState
{
    private readonly RingViewGameobject ring;

    //Constructor
    public ReturnToOldPinState(RingViewGameobject ringViewGameobject)
    {
        this.ring = ringViewGameobject;
    }


    public void UpdateState()
    {

    }

    public void ToDraggableState()
    {
        ring.currentState = ring.draggableState;
    }

    public void ToReturnToOldPinState()
    {
        Debug.Log("Already in ReturnToOldPinState");
    }

    public void ToIdleState()
    {
        ring.DraggableObject.isDRaggable = false;
        ring.currentState = ring.idleState;
    }


}
