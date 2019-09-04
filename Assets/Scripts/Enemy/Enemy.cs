using System.Collections;
using UnityEngine;

public enum EnemyState
{
    idle, walk, attack, stagger, standing
}

public class Enemy : MonoBehaviour {

    [Header("State machine")]
    public EnemyState currentState;

    [Header("Enemy stats")]
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public Vector2 homePosition;

    [Header("Effects")]
    public GameObject deathEffect;
    public float deathEffectDelay = 1f;
    public LootTable thisLoot;

    [Header("Signals")]
    public Signal roomSignal;
    

    private void Awake()
    {
        health = maxHealth.initialValue;
        
    }
    
     private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathEffect();
            MakeLoot();
            if (roomSignal != null)
            {
                roomSignal.Raise();
            }
            
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }

    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            //myRigidbody.bodyType = RigidbodyType2D.Kinematic;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    } 
}
