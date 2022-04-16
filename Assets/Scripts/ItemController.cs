using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To Drag the spwaned object with mouse movement or touch movement.
public class ItemController : MonoBehaviour
{
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;

    //Adding Collider to run time to the object, so collider will reset and size of collider will set accordingly to object size.
    void Start()
    {
        this.gameObject.AddComponent<CapsuleCollider2D>();

    }

    //Dragging object with mousemovement.
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            this.gameObject.transform.localPosition = new Vector3(pos.x - startPosX, pos.y - startPosY, 0);
        }
        
    }
    //Getting the position of object and enabling the movement of object
    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;
           
        }
    }
    // Disabling the movement of object when mousebutton up
    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
    // Detecting collision with object to disabling the movement of object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBeingHeld = false;
    }


}
