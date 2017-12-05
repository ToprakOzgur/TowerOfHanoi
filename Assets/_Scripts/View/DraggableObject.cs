using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DraggableObject : MonoBehaviour
{

    private Vector3 gameObjectCenter; // center of gameobject
    private Vector3 touchPosition; //touch or click position
    private Vector3 offset; // vector between touchpoint/mouseclick to object center
    private Vector3 newGameObjectCenter; // new center of gameobject
    private Rigidbody2D rigidBody;
    private bool isDragging = false;

    [SerializeField]
    private int maxRotationLimitWhenDragging = 30;

    [HideInInspector]
    public bool isDRaggable = false;

    #region Unity_Functions

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (!isDRaggable)
            return;
        gameObjectCenter = transform.position;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = touchPosition - gameObjectCenter;

        rigidBody.gravityScale = 0;

    }

    private void OnMouseUp()
    {
        rigidBody.gravityScale = 1;
        isDragging = false;
    }

    private void OnMouseDrag()
    {
        if (!isDRaggable)
            return;
        isDragging = true;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newGameObjectCenter = touchPosition - offset;
        LimitRotation(); //to prevent unrealistic behaviours when  rotating too much (only when dragging )
    }


    private void FixedUpdate()
    {
        if (!isDragging)
            return;
        if (!isDRaggable)
            return;
        var distance = newGameObjectCenter - transform.position; //distance vector to target. 
        if (distance.magnitude < 0.1f) // stopping dragging here when rigidbody close enough to target to prevent  unrealistic movement of object.
        {
            rigidBody.velocity = Vector2.zero;
            return;
        }

        var movement = new Vector2(distance.x, distance.y).normalized
                                                          * Time.fixedDeltaTime
                                                          * RelativeMovementSpeed(distance);//movement Vector
        rigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + movement); //moving rb to target
    }

    #endregion


    private float RelativeMovementSpeed(Vector3 distanceToTarget)
    {
        //This method is required for smooth movement of rigidbody.
        //While speed is constant, vibrations (  fast cursor  movements) and discrete movement ( slow cursor movements)  happens
        //So this method changes the speed according to the cursor movement(Bigger distanceToTarget means faster swipe movement ). 

        var distanceMagnitude = distanceToTarget.magnitude;
        var minSpeed = 5.0f; //speeds at slower movements
        var maxSpeed = 75.0f; //speeds at faster movements
        var speedMultiplier = 3;

        return Mathf.Clamp(Mathf.Pow(distanceMagnitude, speedMultiplier), minSpeed, maxSpeed);

    }

    private void LimitRotation()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                           transform.eulerAngles.y,
                                            Utility.ClampRotation(transform.eulerAngles.z, maxRotationLimitWhenDragging));
    }


}
