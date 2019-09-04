using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable {
    

    [Header("Content")]
    public Item contents;
    public bool isOpen;
    public BoolValue isStoredOpen;
    public Inventory playerInventory;

    [Header("Signals")]
    public Signal raiseItem;

    [Header("Dialogs")]
    public GameObject dialogBox;
    public Text dialogText;
    
    [Header("Animation")]
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isOpen = isStoredOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("isOpen", true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
        
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;

        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        

        raiseItem.Raise();
        isOpen = true;
        contextOn.Raise();
        contextOff.Raise();
        anim.SetBool("isOpen", true);
        isStoredOpen.RuntimeValue = isOpen;
        
    }

    public void ChestAlreadyOpen()
    {
        playerInRange = false;
        dialogBox.SetActive(false);
        
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger && !isOpen)
        {
            playerInRange = true;
            contextOn.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
            contextOff.Raise();
        }
    }
}
