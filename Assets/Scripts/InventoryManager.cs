using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class dealing with creating ItemUI(inventory item) and spwan desir eobjects from inventory item.
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

    //Adding Observer pattern, creating event.
    public event Action <Sprite> OnGenerateButtonClick;

    //Subscribing OnGenerateButtonClick's event.
    private void OnEnable()
    {
        OnGenerateButtonClick += GenerateObject;
    }

    //Adding Listener of buttons and event's listener,doing generateButton disabled because first image will be selected then after generatebutton will enable.
    private void Start()
    {
        
        generateBtn.onClick.AddListener(() => InvokeOnGenerateButton(selectedObjectSprite));
        backBtn.onClick.AddListener(OnBackBtnClick);
        generateBtn.enabled = false;
    }

    private void Update()
    {
        DetectGameObject();
    }

    //Creating ItemUI(inventory item) object and setting the data from inventorySO.
    public void CreateInventory()
    {
        for(int i=0; i< inventorySOList.inventoryItem.Length; i++)
        {
            GameObject item = Instantiate(inventoryPrefab, ContentTransform);
            item.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySOList.inventoryItem[i].ObjectImage;

        }
    }

    //To Open Lobby.
    private void OnBackBtnClick()
    {
        lobbyPanel.SetActive(true);
        ObjectSpwanPoint.SetActive(false);
        levelPanel.SetActive(false);

    }

    // When generate button clicked new spwanObject will be created for main content area and setting the data and localscale.
    private void GenerateObject(Sprite objectSprite)
    {
        GameObject ObjectItem = Instantiate(spwanObjectPrefab, transform.position ,Quaternion.identity, ObjectSpwanPoint.transform);
        ObjectItem.GetComponent<SpriteRenderer>().sprite = objectSprite;
        ObjectItem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    // To clicked on desired inventory item which want to spwan.
    public void DetectGameObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

           // when mouse button clicked raycast will hit and if raycast found collider sprite will be get from gameobject.
            if (hit && hit.collider != null && hit.collider.gameObject.GetComponent<ChangeFrame>())
            {
                selectedObjectSprite = hit.collider.gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
                generateBtn.enabled = true;
               
            }

        }
    }

    //will invoke when generatebuttonclicked
    public void InvokeOnGenerateButton(Sprite objectSprite)
    {
        OnGenerateButtonClick?.Invoke(objectSprite);
    }

    //Unsubscribing OnGenerateButtonClick's event.
    private void OnDisable()
    {
        OnGenerateButtonClick -= GenerateObject;
    }

}
