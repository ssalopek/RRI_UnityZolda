using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour {

    [Header("UI to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("Item variables")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    public void Clicked()
    {
        if (thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.isUsable, thisItem);
        }
    }

}
