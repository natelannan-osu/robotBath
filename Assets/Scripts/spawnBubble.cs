﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBubble : MonoBehaviour {

	public float timeToSpawn = 5.0f;
	public GameObject bubbleObject;
	public Sprite bubbleSprite;
//	public int maxBubbles = 3;
	private float additionalWait;
	private float countdown;
	private GameObject bubble;
	private bool inflating  = false;
//	public static int bubbleCount = 0;
	static private bool reset = false;
	private bool localReset = true;
	static private int allReset = 0;
	private float range = 2.0f;
	[HideInInspector]
	public float bubbleSpeed = -0.01f;
	private float timeOffset = 0f;
	private Rigidbody2D bubbleRB;
	// Use this for initialization
	void Start () {
		additionalWait = Random.Range (0.0f, 3.0f);
		countdown = additionalWait;
//		if (popBubble.poppedCount == 0 && robotControllerScript.lives == 3) {
			timeOffset = Time.time;
//		}
	}
	
	// Update is called once per frame
	void Update () {

		if (timeToSpawn > 0f) {
			timeToSpawn = 5.0f - (Time.time-timeOffset) / 30;
		}
		bubbleSpeed = -.01f - (Time.time-timeOffset) / 3000;

			
		if (reset && localReset) {
			additionalWait = Random.Range (0.0f, range);
			countdown = timeToSpawn + additionalWait;
			localReset = false;
			allReset++;	
			if (allReset == 6) {
				reset = false;
				allReset = 0;
			}
		} else if (!reset) {
			localReset = true;
		}

		if (countdown <= 0 /*&& bubbleCount < maxBubbles*/) {
			if (transform.childCount == 0) {
				makeBubble ();
			}
			additionalWait = Random.Range (0.0f, 2.0f);
			countdown = timeToSpawn + additionalWait;
		} else {
			countdown -= Time.deltaTime;
		}
		if (inflating) {
			inflate ();
		}

		
	}

	void makeBubble () {
		// Create bubble
		bubble = Instantiate (bubbleObject);
		// Set soapDish as parent
		bubble.transform.parent = transform;
		// Set the sort layer.
		bubble.GetComponent<SpriteRenderer> ().sortingLayerName = "bubbles";
		// Set the transform values of the bubble.
		bubble.transform.localPosition = new Vector3 (0f, .05f, 0f);
		//bubbleCount++;
		//bubble.transform.parent = null;
		reset = true;
		localReset = false;
		allReset++;	
		inflating = true;
	}

	void inflate () {
		bubbleRB = bubble.GetComponent<Rigidbody2D> ();
		bubble.transform.localScale += new Vector3(.01f, .01f, 0);
		if (bubble.transform.localScale.x > 1f) {
			bubbleRB.gravityScale  = bubbleSpeed;
			inflating = false;
			bubble.transform.parent = null;
		}
	}
}
