using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObject/NewInventorySO")]
public class InventorySO : ScriptableObject
{

     public InventoryType inventoryType;
     public string inventoryName;
     public Sprite ObjectImage;
  

}
[CreateAssetMenu(fileName = "InventorySOList", menuName = "ScriptableObjectsList/NewInventorySOList")]
public class InventorySOList : ScriptableObject
{
    public InventorySO[] inventoryItem;
}