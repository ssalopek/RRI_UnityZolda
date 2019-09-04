using UnityEngine;

public class PlayerHP : GenericHP {

    [SerializeField] private Signal healthSignal;

    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        maxHealth.RunTimeValue = currentHealth;
        healthSignal.Raise();
    }
}
