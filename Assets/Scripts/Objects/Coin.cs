using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp {

    public Inventory playerInventory;
    public AudioSource coinAudio;

	// Use this for initialization
	void Start () {
        powerUpSignal.Raise();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            coinAudio.Play();
            playerInventory.coins += 1;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
