using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableObject))]
public class RingViewGameobject : MonoBehaviour
{
    //I used STATE DESIGN PATTERN for ring views
    [HideInInspector] public IRingState currentState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public DraggableState draggableState;
    [HideInInspector] public ReturnToOldPinState returnToOldPinState;
    [HideInInspector] public ControlPinState controlPinState;

    [HideInInspector] public int currenPin = 1;
    [HideInInspector] public GameLogicController contoller;
    public int ringNumber;
    public LayerMask mask;

    private void Awake()
    {
        //initializing states
        idleState = new IdleState(this);
        draggableState = new DraggableState(this);
        returnToOldPinState = new ReturnToOldPinState(this);
        controlPinState = new ControlPinState(this);
    }

    private void Start()
    {
        if (ringNumber == 1)
        {
            currentState = draggableState;
        }
        else
        {
            currentState = idleState;
            currentState.ToIdleState();
        }
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        currentState.OnCollisionStay2D(collision);
    }

    #region ReturnToOldPin State functions.
    //States classes are not MonoBehaviour. So, to be able to use Coroutines i called  from here. 
    public void MoveTo(Vector3 position, float duration)
    {
        StartCoroutine(Move(position, duration));
    }

    IEnumerator Move(Vector3 targetPosition, float duration)
    {
        var colliders = gameObject.GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, Utility.BounceEaseOut(t));
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.identity, t);
            yield return null;
        }

        foreach (var col in colliders)
        {
            col.enabled = true;
        }
        currentState = draggableState;
    }

    #endregion
}



