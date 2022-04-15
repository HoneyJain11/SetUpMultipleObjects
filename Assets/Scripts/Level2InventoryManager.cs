using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2InventoryManager : MonoBehaviour
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
    InventorySOList inventorySOList;
    [SerializeField]
    RectTransform ContentTransform;

    private void Start()
    {
        
        generateBtn.onClick.AddListener(CreateInventory);
        backBtn.onClick.AddListener(OnBackBtnClick);
        
    }



    public void CreateInventory()
    {
        GameObject item = Instantiate(inventoryPrefab, ContentTransform);
        item.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySOList.inventoryItem[UnityEngine.Random.Range(0,6)].ObjectImage;

        
    }

    private void OnBackBtnClick()
    {
        lobbyPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
}
