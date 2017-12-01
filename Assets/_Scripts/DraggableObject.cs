using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DraggableObject : MonoBehaviour
{

    private Vector3 gameObjectCenter; // center of gameobject
    private Vector3 touchPosition; //touch or click position
    private Vector3 offset; // vector between touchpoint/mouseclick to object center
    private Vector3 newGameObjectCenter; // new center of gameobject
    private Rigidbody2D rigidBody;
    //  private bool isDragging = false;

    #region Unity_Functions
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        gameObjectCenter = transform.position;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = touchPosition - gameObjectCenter;

        rigidBody.gravityScale = 0;

    }

    void OnMouseUp()
    {
        rigidBody.gravityScale = 1;
        // isDragging = false;
    }

    void OnMouseDrag()
    {
        // isDragging = true;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newGameObjectCenter = touchPosition - offset;

        transform.position = new Vector3(newGameObjectCenter.x, newGameObjectCenter.y, transform.position.z);

    }

    //void FixedUpdate()
    //{
    //    if (!isDragging)
    //        return;


    //    rigidBody.MovePosition(new Vector3(newGameObjectCenter.x, newGameObjectCenter.y, transform.position.z) * Time.deltaTime);

    //}

    #endregion Unity


}
