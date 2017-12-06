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
        ring.GetComponent<Rigidbody2D>().isKinematic = false;
        ring.currentState = ring.draggableState;
    }

    public void ToReturnToOldPinState()
    {

    }

    public void ToIdleState()
    {
        ring.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void ToControlPinState()
    {

    }

    public void OnCollisionStay2D(Collision2D collision)
    {

    }
}
