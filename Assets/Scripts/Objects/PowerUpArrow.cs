using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArrow : PowerUp {

    public Inventory playerInventory;
    public float arrowValueMax;
    public float arrowValue;

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(arrowValue >= arrowValueMax)
            {
                arrowValue = arrowValueMax;
            }
            else
            {
                playerInventory.currentArrows += arrowValue;
                powerUpSignal.Raise();
                Destroy(this.gameObject);
            }
            
        }
    }
}
