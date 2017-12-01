using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerExitHandler
{
    private Rigidbody2D rigidBody2d;
    private HingeJoint2D springJoint;
    private GameObject dragPrefab;
    private bool isDragging = false;
    [SerializeField]
    private int rotationLimit;

    [HideInInspector]
    public bool isTouchingPin = false;

    private void Start()
    {
        dragPrefab = Resources.Load("DragPoint") as GameObject;
        rigidBody2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!isDragging)
            return;

        var zAngle = Utility.ClampRotation(transform.eulerAngles.z, rotationLimit); // prevent unrealistic behaviours.

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zAngle);
    }

    public void OnDrag(PointerEventData eventData)
    {

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (springJoint != null)
        {
            var xPos = isTouchingPin == true ? springJoint.transform.position.x : mousePos.x;
            springJoint.transform.position = new Vector3(xPos, mousePos.y, springJoint.transform.position.z);
        }


    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        isDragging = true;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var jointTrans = Instantiate(dragPrefab, mousePosition, transform.rotation) as GameObject;

        springJoint = jointTrans.GetComponent<HingeJoint2D>();
        springJoint.connectedAnchor = transform.InverseTransformPoint(mousePosition);


        springJoint.connectedBody = rigidBody2d;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        isDragging = false;
        if (springJoint != null)
            Destroy(springJoint.gameObject);

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Debug.Log("exit");
    }
}


