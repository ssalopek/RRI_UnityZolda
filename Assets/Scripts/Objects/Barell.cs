using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour {

    private Animator anim;
    public LootTable thisLoot;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
        StartCoroutine(BreakCo());
        MakeLoot();
    }

    IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }

}
