using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory/Player inventory")]
public class PlayerInventory : ScriptableObject {

    public List<InventoryItem> myInventory = new List<InventoryItem>();


}
