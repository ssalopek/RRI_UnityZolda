using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool isActive;
    public BoolOnlyValue isStoredBoodValue;
    public Sprite activeSprite;
    public Door thisDoor;

    private SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        isActive = isStoredBoodValue.RuntimeValue;
        if (isActive)
        {
            ActivateButton();
        }
	}

    public void ActivateButton()
    {
        isActive = true;
        isStoredBoodValue.RuntimeValue = isActive;
        thisDoor.OpenDoor();
        mySprite.sprite = activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ActivateButton();
        }
    }
}
