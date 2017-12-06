using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOldPinState : IRingState
{
    private readonly RingViewGameobject ring;
    public Transform oldPinTopPosition;


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
        ring.currentState = ring.idleState;
    }

    public void ToControlPinState()
    {
        Debug.LogWarning("transition is not possible Check Again !!!");
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
            ReturnBack();
    }

    private void ReturnBack()
    {

        ring.MoveTo(oldPinTopPosition.position, 1f);

        //ring.transform.position = oldPinTopPosition.position;

    }
}
