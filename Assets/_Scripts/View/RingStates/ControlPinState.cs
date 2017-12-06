using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPinState : IRingState
{
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;
    private readonly RingViewGameobject ring;
    private float controlTimer;
    private float controlDuration = 3.0f;

    //Constructor
    public ControlPinState(RingViewGameobject ringViewGameobject)
    {
        this.ring = ringViewGameobject;
    }


    public void UpdateState()
    {
        CheckIfRingIsOnThePin();
        Timer();
    }

    public void ToDraggableState()
    {
        ring.currentState = ring.draggableState;
    }

    public void ToReturnToOldPinState()
    {
        controlTimer = 0;
        ring.currentState = ring.returnToOldPinState;
        ring.returnToOldPinState.ReturnBack();
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

    private void CheckIfRingIsOnThePin()
    {
        hitRight = Physics2D.Raycast(ring.transform.position, Vector2.right, 1, ring.mask);
        hitLeft = Physics2D.Raycast(ring.transform.position, Vector2.left, 1, ring.mask);
        //Debug.DrawRay(ring.transform.position, Vector2.left, Color.red);
        //Debug.DrawRay(ring.transform.position, Vector2.right, Color.red);

        if (hitRight.collider != null && hitLeft.collider != null && hitRight.collider.tag == hitLeft.collider.tag)
            ring.contoller.RingIsOnThePin(hitRight, ring.ringNumber);
    }

    private void Timer()
    {
        controlTimer += Time.deltaTime;
        if (controlTimer >= controlDuration)
            ToReturnToOldPinState();
    }
}
