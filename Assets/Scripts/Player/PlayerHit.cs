using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    public Animator anim;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Breakable"))
        {
            collider.GetComponent<Barell>().Smash();
        } 
    }
}
