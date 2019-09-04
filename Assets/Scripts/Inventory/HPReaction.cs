using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPReaction : MonoBehaviour {

    public FloatValue playerHP;
    public Signal hpSignal;

    public void Use(int amountToIncrease)
    {
        playerHP.RunTimeValue += amountToIncrease;
        hpSignal.Raise();
    }
}
