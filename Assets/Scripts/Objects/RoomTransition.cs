﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour {

    public Vector2 cameraChange;
    public Vector3 playerChange;

    private CameraMovement cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            collider.transform.position += playerChange;
        }
    }
}
