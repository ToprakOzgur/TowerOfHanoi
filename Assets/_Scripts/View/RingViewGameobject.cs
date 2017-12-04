using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingViewGameobject : MonoBehaviour
{

    [SerializeField] int ringNumber;
    [SerializeField] LayerMask mask;

    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;
    private readonly WaitForSeconds raycastCheckTime = new WaitForSeconds(0.2f); //declaring  waitforseconds here is a little "bit" :) better for Memory/GarbageCollection
    private Coroutine raycastCoroutine;

    public event Action<RaycastHit2D, int> OnRingIsOnThePinEvent; //Action used for VIEW-TO-CONTROLLER comminication for MVC design pattern

    private void Start()
    {

        StartLauncRaycastsCoroutine();
    }

    public void StartLauncRaycastsCoroutine()
    {
        raycastCoroutine = StartCoroutine(DetectIfatPinByRaycasting()); //to be able to stop coroutine later,We should assign it to a Coroutine variable.
    }

    public void StopLauncRaycastsCoroutine()
    {
        StopCoroutine(raycastCoroutine);
    }

    //I prefer using Coroutines  instead of FixedUpdate beacause of mobile performance/FPS.
    // At much  more complex games  "Updates" can cause performance problems.
    IEnumerator DetectIfatPinByRaycasting()
    {
        while (true)
        {
            hitRight = Physics2D.Raycast(transform.position, Vector2.right, 1, mask);
            hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 1, mask);
            //Debug.DrawRay(transform.position, Vector2.left, Color.red);
            //Debug.DrawRay(transform.position, Vector2.right, Color.red);

            if (hitRight.collider != null && hitRight.collider != null && hitRight.collider.tag == hitLeft.collider.tag)
            {
                if (OnRingIsOnThePinEvent != null)
                    OnRingIsOnThePinEvent(hitRight, ringNumber);
                StopLauncRaycastsCoroutine();
            }
            yield return raycastCheckTime;
        }

    }
}
