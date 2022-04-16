using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Making ScriptableObject of inventory item
[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObject/NewInventorySO")]
public class InventorySO : ScriptableObject
{

     public InventoryType inventoryType;
     public string inventoryName;
     public Sprite ObjectImage;
  
}

//Making ScriptableObject which stores the  inventory item ScriptableObjects
[CreateAssetMenu(fileName = "InventorySOList", menuName = "ScriptableObjectsList/NewInventorySOList")]
public class InventorySOList : ScriptableObject
{
    public InventorySO[] inventoryItem;
}