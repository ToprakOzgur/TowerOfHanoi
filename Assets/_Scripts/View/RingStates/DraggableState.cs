using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableState : IRingState
{
    private readonly RingViewGameobject ring;

    //TODO: delete
    public bool isThereAnotherRingOrPlateBelow = false;// pushing a rigibody towards another static rigidbody (below rings and red plate) causes unwanted behaviours like vibrating,jumping. This variable is used to solve this isue

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

    public void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void CheckIfRingIsOnTheRing()
    {
        //if right and left raycast hits same pin,ring is on the pin
        //  var hitDown = Physics2D.Raycast(ring.transform.position, Vector2.down, 1,);
        //Debug.DrawRay(ring.transform.position, Vector2.down, Color.red);
        //Debug.Log(hitDown.transform.gameObject.name);
        //if (hitDown.collider.CompareTag("Ring") || hitDown.collider.CompareTag("Plate"))
        //Debug.Log("engel");
    }

}
