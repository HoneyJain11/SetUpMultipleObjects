using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
// This class dealing with the elements of lobby.
public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    Button level1Btn;
    [SerializeField]
    Button level2Btn;
    [SerializeField]
    Button quitBtn;
    [SerializeField]
    InventoryManager inventoryManager;
    [SerializeField]
    GameObject levelPanel;
    [SerializeField]
    GameObject lobbyPanel;
    [SerializeField]
    GameObject level2Panel;
    [SerializeField]
    Button level2BackBtn;
    [SerializeField]
    GameObject ObjectSpwanPoint;

    //In start Adding listener of buttons and calling CreateInventory function from InventoryManager to create ItemUI(inventory item)object.
    private void Start()
    {
        level1Btn.onClick.AddListener(Openlevel1);
        level2Btn.onClick.AddListener(Openlevel2);
        level1Btn.onClick.AddListener(QuitGame);
        inventoryManager.CreateInventory();
    }
    //To Open Level 1 and also enabling ObjectSpwanPoint
    private void Openlevel1()
    {
        levelPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        ObjectSpwanPoint.SetActive(true);

    }
    //To Open Level 2 
    private void Openlevel2()
    {
        level2Panel.SetActive(true);
        lobbyPanel.SetActive(false);
    }
    // To quit the application.
    private void QuitGame()
    {
        Application.Quit();
    }
}
