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
        CheckIfRingIsOnTheRing();
    }

    public void ToDraggableState()
    {
        ring.currentState = ring.draggableState;
    }

    public void ToReturnToOldPinState()
    {
        ring.currentState = ring.returnToOldPinState;

    }

    public void ToIdleState()
    {
        ring.GetComponent<Rigidbody2D>().isKinematic = true;
        ring.currentState = ring.idleState;

    }

    public void ToControlPinState()
    {
        ring.currentState = ring.controlPinState;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void CheckIfRingIsOnTheRing()
    {

    }

}
