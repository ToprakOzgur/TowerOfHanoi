using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerExitHandler
{
    private Rigidbody2D rigidBody2d;
    private SpringJoint2D springJoint;
    private GameObject dragPrefab;
    private bool isDragging = false;
    [SerializeField]
    private int rotationLimit;

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
        Debug.Log("OnDrag");
        if (springJoint != null)
            springJoint.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        isDragging = true;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var jointTrans = Instantiate(dragPrefab, mousePosition, transform.rotation) as GameObject;
        springJoint = jointTrans.GetComponent<SpringJoint2D>();
        springJoint.connectedAnchor = transform.InverseTransformPoint(mousePosition);
        springJoint.connectedBody = rigidBody2d;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        isDragging = false;
        if (springJoint != null)
            Destroy(springJoint.gameObject);

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Debug.Log("exit");
    }
}


