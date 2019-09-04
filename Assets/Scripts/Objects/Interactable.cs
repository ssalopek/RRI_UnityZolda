using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public bool playerInRange;
    public Signal contextOn;
    public Signal contextOff;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            playerInRange = true;
            contextOn.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            playerInRange = false;
            contextOff.Raise();
        }
    }
}
