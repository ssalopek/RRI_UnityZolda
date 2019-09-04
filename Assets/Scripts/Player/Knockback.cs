using UnityEngine;

public class Knockback : MonoBehaviour {

    public float thrust;
    public float knockTime;
    public float damage;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Barell>().Smash();
        }

        if (collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collider.GetComponent<Rigidbody2D>();
            if(hit != null) 
            {
                
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                //ForceMode2D.Impulse --> Add an instant force impulse to the rigidbody2D, using its mass.
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (collider.gameObject.CompareTag("Enemy") && collider.isTrigger)
                {
                    //hit.bodyType = RigidbodyType2D.Dynamic;
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collider.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }

                if (collider.gameObject.CompareTag("Player"))
                {
                    if(collider.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        collider.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                    
                }
            }
        }
    }
}
