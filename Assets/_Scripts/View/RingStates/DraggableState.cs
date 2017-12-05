using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableState : IRingState
{
    private readonly RingViewGameobject ring;

    //Constructor
    public DraggableState(RingViewGameobject ringViewGameobject)
    {
        this.ring = ringViewGameobject;
    }

    public void UpdateState()
    {

    }

    public void ToDraggableState()
    {

    }

    public void ToReturnToOldPinState()
    {
        ring.currentState = ring.returnToOldPinState;

    }

    public void ToIdleState()
    {
        ring.currentState = ring.idleState;

    }

    public void ToControlPinState()
    {
        ring.currentState = ring.controlPinState;
    }



}
