using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom {

    public Door[] doors;


	// Use this for initialization
	void Start () {
        OpenDoors();
	}

    public int EnemiesActive()
    {
        int activeEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length)
            {
                activeEnemies++;
            }
        }
        return activeEnemies;
    }

    public void CheckEnemies()
    {
        if (EnemiesActive() == 1)
        {
            OpenDoors();
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider)
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
            CloseDoors();
           // virtualCamera.SetActive(true);
        }
        
    }

    public override void OnTriggerExit2D(Collider2D colider)
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
           // virtualCamera.SetActive(false);
        }
    }

    public void CloseDoors()
    {
        for(int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].OpenDoor();
        }
    }
}
