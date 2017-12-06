using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPinState : IRingState
{
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;

    private readonly RingViewGameobject ring;

    //Constructor
    public ControlPinState(RingViewGameobject ringViewGameobject)
    {
        this.ring = ringViewGameobject;
    }


    public void UpdateState()
    {
        CheckIfRingIsOnThePin();
    }

    public void ToDraggableState()
    {
        ring.currentState = ring.draggableState;
    }

    public void ToReturnToOldPinState()
    {
        Debug.LogWarning("transition is not possible Check Again !!!");
    }

    public void ToIdleState()
    {
        ring.currentState = ring.idleState;

    }

    public void ToControlPinState()
    {
        Debug.Log("Already in ControlState");
    }

    public void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void CheckIfRingIsOnThePin()
    {
        //if right and left raycast hits same pin,ting is on the pin
        hitRight = Physics2D.Raycast(ring.transform.position, Vector2.right, 1, ring.mask);
        hitLeft = Physics2D.Raycast(ring.transform.position, Vector2.left, 1, ring.mask);
        // Debug.DrawRay(ring.transform.position, Vector2.left, Color.red);
        //Debug.DrawRay(ring.transform.position, Vector2.right, Color.red);

        if (hitRight.collider != null && hitLeft.collider != null && hitRight.collider.tag == hitLeft.collider.tag)
        {
            //  ToIdleState();
            ring.InvokeOnRingIsOnThePinEvent(hitRight);

        }

    }
}
