using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartValues : MonoBehaviour {

    public FloatValue playerHp;
    public BoolValue chest;
    public Inventory inventory;
    public BoolValue button;
    public BoolOnlyValue buttonDoor;
     


	// Use this for initialization
	void Start () {
        playerHp.RunTimeValue = playerHp.initialValue;
        chest.RuntimeValue = chest.initialBoolValue;
        inventory.coins = 0;
        inventory.numberOfKeys = 0;
        inventory.currentArrows = 10;
        button.RuntimeValue = button.initialBoolValue;
        buttonDoor.RuntimeValue = buttonDoor.initialBoolValue;

	}
	
	
}
