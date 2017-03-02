using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popSound : MonoBehaviour {
	private AudioSource audioSource;
	public AudioClip pop;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "bubble") { 
			audioSource.PlayOneShot (pop);

		}
	}
}
