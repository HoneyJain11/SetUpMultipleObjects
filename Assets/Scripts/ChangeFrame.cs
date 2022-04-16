using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFrame : MonoBehaviour
{
    Image itemImage;
    //This function will change the color black to red of frame which is image of ItemUI(inventory item),when mouse pointer enter on the ItemUI.
    private void OnMouseEnter()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
        itemImage = hit.collider.gameObject.GetComponent<Image>();
        itemImage.color = Color.red;

    }
    //This function will change the color red to black of frame which is image of ItemUI(inventory item),when mouse pointer exit on the ItemUI.
    private void OnMouseExit()
    {
        itemImage.color = Color.black;
    }
}
