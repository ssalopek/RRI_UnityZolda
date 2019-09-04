using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour {

    [Header("Inventory info")]
    public PlayerInventory playerInventory;

    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string description, bool isButtonActive)
    {
        descriptionText.text = description;
        if (isButtonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    public void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if(playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp =
                    Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);

                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();

                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

	// Use this for initialization
	void OnEnable () {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
	}
	
	public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void ButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            ClearInventorySlots();
            MakeInventorySlots();
            if(currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
            

        }
    }
}
