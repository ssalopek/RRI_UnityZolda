using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInventoryItem : MonoBehaviour {

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !collider.isTrigger)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld++;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}
