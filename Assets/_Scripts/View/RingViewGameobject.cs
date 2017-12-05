using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableObject))]
public class RingViewGameobject : MonoBehaviour
{
    //I used STATE PATTERN for ring views
    [HideInInspector] public IRingState currentState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public DraggableState draggableState;
    [HideInInspector] public ReturnToOldPinState returnToOldPinState;

    public int ringNumber;
    public event Action<RaycastHit2D, int> OnRingIsOnThePinEvent; //Event used for VIEW-TO-CONTROLLER comminication for MVC design pattern
    public LayerMask mask;

    private DraggableObject draggableObject;
    public DraggableObject DraggableObject
    {
        get
        {
            if (draggableObject == null)
                draggableObject = GetComponent<DraggableObject>();

            return draggableObject;
        }
    }


    private void Awake()
    {
        idleState = new IdleState(this);
        draggableState = new DraggableState(this);
        returnToOldPinState = new ReturnToOldPinState(this);
    }

    private void Start()
    {
        currentState = idleState;
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void InvokeOnRingIsOnThePinEvent(RaycastHit2D result)
    {
        if (OnRingIsOnThePinEvent != null)
            OnRingIsOnThePinEvent(result, ringNumber);
    }

}
