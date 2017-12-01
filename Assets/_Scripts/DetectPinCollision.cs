using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPinCollision : MonoBehaviour
{

    public Draggable dragObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        dragObject.isTouchingPin = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.LogError(collision.gameObject.name + " den çıktı");
        dragObject.isTouchingPin = false;
    }
}
