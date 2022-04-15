using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFrame : MonoBehaviour
{
    Image itemImage;
    private void OnMouseEnter()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
        Debug.Log("Hit with GameObject " + hit.collider.gameObject.name);
        itemImage = hit.collider.gameObject.GetComponent<Image>();
        itemImage.color = Color.red;

    }
    private void OnMouseExit()
    {
        itemImage.color = Color.black;
    }
}
