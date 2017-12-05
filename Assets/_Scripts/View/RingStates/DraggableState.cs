using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableState : IRingState
{
    private readonly RingViewGameobject ring;

    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;

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
        Debug.Log("Already in DraggableState");
    }

    public void ToReturnToOldPinState()
    {
        ring.currentState = ring.returnToOldPinState;
        ring.DraggableObject.isDRaggable = false;
    }

    public void ToIdleState()
    {
        ring.currentState = ring.idleState;
        ring.DraggableObject.isDRaggable = false;
    }

    private void CheckIfRingIsOnTheRing()
    {
        hitRight = Physics2D.Raycast(ring.transform.position, Vector2.right, 1, ring.mask);
        hitLeft = Physics2D.Raycast(ring.transform.position, Vector2.left, 1, ring.mask);
        Debug.DrawRay(ring.transform.position, Vector2.left, Color.red);
        Debug.DrawRay(ring.transform.position, Vector2.right, Color.red);

        if (hitRight.collider != null && hitRight.collider != null && hitRight.collider.tag == hitLeft.collider.tag)
        {
            ring.InvokeOnRingIsOnThePinEvent(hitRight);

        }

    }

}
