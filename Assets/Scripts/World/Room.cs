using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public Enemy[] enemies;
    public Barell[] barells;
    public ResetToPosition[] pushableObjects;
    //public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < barells.Length; i++)
            {
                ChangeActivation(barells[i], true);
            }
           // virtualCamera.SetActive(true);
           for(int i = 0; i< pushableObjects.Length; i++)
            {
                pushableObjects[i].ResetPosition();
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D colider)
    {
        if (colider.CompareTag("Player") && !colider.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < barells.Length; i++)
            {
                ChangeActivation(barells[i], false);
            }
            //virtualCamera.SetActive(false);
            for (int i = 0; i < pushableObjects.Length; i++)
            {
                pushableObjects[i].ResetPosition();
            }
        }
    }

    public void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
