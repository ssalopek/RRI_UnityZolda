using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour {

    public Inventory playerInventory;
    public TextMeshProUGUI coinText;

	public void UpdateCoinCount()
    {
        coinText.text = "" + playerInventory.coins;
    }
}
