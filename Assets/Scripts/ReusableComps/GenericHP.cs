using UnityEngine;

public class GenericHP : MonoBehaviour {

    public FloatValue maxHealth;
    public float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth.RunTimeValue;
	}
	
	public virtual void Heal(float amountToHeal)
    {
        currentHealth += amountToHeal;
        if(currentHealth > maxHealth.RunTimeValue)
        {
            currentHealth = maxHealth.RunTimeValue;
        }
    }

    public virtual void FullHeal()
    {
        currentHealth = maxHealth.RunTimeValue;
    }

    public virtual void Damage(float amountToDamage)
    {
        currentHealth -= amountToDamage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public virtual void InstantDeath()
    {
        currentHealth = 0;
    }
}
