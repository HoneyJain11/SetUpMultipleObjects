using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class dealing with Level 2 inventory items.
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

    //Adding Listener of generate button and back button.
    private void Start()
    {
        generateBtn.onClick.AddListener(CreateInventory);
        backBtn.onClick.AddListener(OpenLobby);
        
    }
    //creating object when generate button clicked, object getting random sprite from inventoryItemSO through using RandomRange.
    public void CreateInventory()
    {
        GameObject item = Instantiate(inventoryPrefab, ContentTransform);
        item.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySOList.inventoryItem[UnityEngine.Random.Range(0,6)].ObjectImage;

    }
    //Return to lobbyPanel.
    private void OpenLobby()
    {
        lobbyPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
}
