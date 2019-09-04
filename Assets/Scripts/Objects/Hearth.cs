using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : PowerUp {

    public FloatValue playerHealth;
    public FloatValue hearthContainers;
    public float amountToInc;
    public FloatValue maxHealth;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && !collider.isTrigger)
        {
            if(playerHealth.RunTimeValue >= maxHealth.initialValue)
            {
                playerHealth.RunTimeValue = maxHealth.initialValue;
            }
            else
            {
                playerHealth.RunTimeValue += amountToInc;
                if (playerHealth.RunTimeValue > hearthContainers.RunTimeValue * 2f)
                {
                    playerHealth.initialValue = hearthContainers.RunTimeValue * 2f;
                }
                powerUpSignal.Raise();
                Destroy(this.gameObject);
            }
            
        }
    }
}
