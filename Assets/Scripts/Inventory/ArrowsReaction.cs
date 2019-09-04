using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsReaction : MonoBehaviour {

    public FloatValue playerArrows;
    public Signal arrowSignal;

	public void Use(int amountToIncrease)
    {
        playerArrows.RunTimeValue += amountToIncrease;
        arrowSignal.Raise();
    }
}
