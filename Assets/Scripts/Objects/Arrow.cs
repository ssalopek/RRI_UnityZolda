using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed;
    public Rigidbody2D myRigidbody;
    public float lifetime;
    public float arrowCost;

    private float lifetimeCounter;

	// Use this for initialization
	void Start () {
        lifetimeCounter = lifetime;
	}

    private void Update()
    {
        lifetimeCounter -= Time.deltaTime;
        if(lifetimeCounter <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction); //to rotate arrow object

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
