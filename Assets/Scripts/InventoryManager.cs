using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
     Button generateBtn;
    [SerializeField]
    Button backBtn;
    [SerializeField]
    GameObject inventoryPrefab;
    [SerializeField]
    GameObject lobbyPanel;
    [SerializeField]
    GameObject levelPanel;
    [SerializeField]
    GameObject spwanObjectPrefab;
    [SerializeField]
     InventorySOList inventorySOList;
    [SerializeField]
     RectTransform ContentTransform;
    [SerializeField]
    GameObject ObjectSpwanPoint;
    Sprite selectedObjectSprite;

    public event Action <Sprite> OnGenerateButtonClick;

    public void InvokeOnGenerateButton(Sprite objectSprite)
    {
        OnGenerateButtonClick?.Invoke(objectSprite);
    }
    private void Start()
    {
        OnGenerateButtonClick += GenerateObject;
        generateBtn.onClick.AddListener(() => InvokeOnGenerateButton(selectedObjectSprite));
        backBtn.onClick.AddListener(OnBackBtnClick);
        generateBtn.enabled = false;
    }

    public void CreateInventory()
    {
        for(int i=0; i< inventorySOList.inventoryItem.Length; i++)
        {
            GameObject item = Instantiate(inventoryPrefab, ContentTransform);
            item.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySOList.inventoryItem[i].ObjectImage;

        }
    }

    private void OnBackBtnClick()
    {
        lobbyPanel.SetActive(true);
        ObjectSpwanPoint.SetActive(false);
        levelPanel.SetActive(false);

    }

    private void GenerateObject(Sprite objectSprite)
    {
        
        GameObject ObjectItem = Instantiate(spwanObjectPrefab, transform.position ,Quaternion.identity, ObjectSpwanPoint.transform);
        ObjectItem.GetComponent<SpriteRenderer>().sprite = objectSprite;
        ObjectItem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    private void Update()
    {
        DetectGameObject();
    }

    public void DetectGameObject()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
            
            
            if (hit && hit.collider != null)
            {
                selectedObjectSprite = hit.collider.gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
                generateBtn.enabled = true;
               
            }

        }
    }
   
    private void OnDisable()
    {
       // OnGenerateButtonClick -= GenerateObject;
    }

}
