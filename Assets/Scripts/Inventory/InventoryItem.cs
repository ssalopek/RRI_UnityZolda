using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject {

    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool isUsable;
    public bool isUnique;
    public UnityEvent thisEvent;

    public void Use()
    {
        thisEvent.Invoke();
    }

    public void DescreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease ;
        if(numberHeld < 0)
        {
            numberHeld = 0;
        }
    }
	
}
