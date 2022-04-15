using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            this.gameObject.transform.localPosition = new Vector3(pos.x - startPosX, pos.y - startPosY, 0);
        }
        
    }
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

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBeingHeld = false;
    }


    private void ClampObject()
    {
        transform.position = new Vector3(
        //x
        Mathf.Clamp(transform.position.x, -4f, 8f),
        //y
        Mathf.Clamp(transform.position.y, -4f, 5f),
        //z
        0f
        );
    }


}
