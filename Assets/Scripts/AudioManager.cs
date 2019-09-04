using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip audioClip;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource.clip = audioClip;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
