using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed;
    public Vector2 directionToMove;

    [Header("Lifetime")]
    public float lifeTime;
    private float lifeTimeSeconds;

    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        lifeTimeSeconds = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
        lifeTimeSeconds -= Time.deltaTime;
        if(lifeTimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void Launch(Vector2 initialVelocity)
    {
        myRigidbody.velocity = initialVelocity * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
