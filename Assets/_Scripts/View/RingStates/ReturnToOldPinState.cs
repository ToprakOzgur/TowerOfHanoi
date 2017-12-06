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

    }

    public void ToIdleState()
    {
        ring.currentState = ring.idleState;
        ring.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void ToControlPinState()
    {

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
            ReturnBack();
    }

    public void ReturnBack()
    {
        var pos = ring.contoller.pinPositions[ring.currenPin - 1].position;
        ring.MoveTo(pos, 1f);
    }
}
