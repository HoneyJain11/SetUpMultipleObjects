using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

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


    private void Start()
    {
        level1Btn.onClick.AddListener(Openlevel1);
        level2Btn.onClick.AddListener(Openlevel2);
        level1Btn.onClick.AddListener(QuitGame);
        level2BackBtn.onClick.AddListener(OpenLobby);

        inventoryManager.CreateInventory();
    }

    private void OpenLobby()
    {
        lobbyPanel.SetActive(true);
        level2Panel.SetActive(false);
        
    }

    private void Openlevel1()
    {
        levelPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        ObjectSpwanPoint.SetActive(true);


    }
    private void Openlevel2()
    {
        level2Panel.SetActive(true);
        lobbyPanel.SetActive(false);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
