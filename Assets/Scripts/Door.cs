using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key, enemy, button
}

public class Door : Interactable {

    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool isOpen = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsColider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if(playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    OpenDoor();
                }
            }
        }
    }

    public void OpenDoor()
    {
        doorSprite.enabled = false;
        isOpen = true;
        physicsColider.enabled = false;
    }

    public void CloseDoor()
    {
        doorSprite.enabled = true;
        isOpen = false;
        physicsColider.enabled = true;
    }
}
