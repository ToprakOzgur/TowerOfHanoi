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

    public int ringNumber;
    public event Action<RaycastHit2D, int> OnRingIsOnThePinEvent; //Event used for VIEW-TO-CONTROLLER comminication for MVC design pattern
    public LayerMask mask;

    private DraggableObject draggableObject;  //assigning variables at Start or Awake function with "GetComponent" is generally used But Sometimes scipts exeecutation order can cause problems.So I prefer to use GetComponent in  properties.
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
        //initializing states
        idleState = new IdleState(this);
        draggableState = new DraggableState(this);
        returnToOldPinState = new ReturnToOldPinState(this);
        controlPinState = new ControlPinState(this);
    }

    private void Start()
    {
        //TODO: HardCoded.Fix it
        if (ringNumber == 1)
        {
            currentState = draggableState;
            currentState.ToDraggableState();
        }
        else currentState = idleState;

    }

    private void Update()
    {
        currentState.UpdateState();
        // Debug.Log("rin: " + ringNumber + " state: " + currentState);
    }

    public void InvokeOnRingIsOnThePinEvent(RaycastHit2D result)
    {
        if (OnRingIsOnThePinEvent != null)
            OnRingIsOnThePinEvent(result, ringNumber);
    }

}
