using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBubble : MonoBehaviour {

	public float timeToSpawn = 2.0f;
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
	// Use this for initialization
	void Start () {
		additionalWait = Random.Range (0.0f, 3.0f);
		countdown = additionalWait;
	}
	
	// Update is called once per frame
	void Update () {
		if (reset && localReset) {
			additionalWait = Random.Range (0.0f, 2.0f);
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
			makeBubble ();
			additionalWait = Random.Range (0.0f, 2.0f);
			countdown = timeToSpawn + additionalWait;
			reset = true;
			localReset = false;
			allReset++;	
			inflating = true;
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
		// Set the transform values of the cannonball.
		bubble.transform.localPosition = new Vector3 (0f, 0f, 0f);
		//bubbleCount++;
		//bubble.transform.parent = null;
	}

	void inflate () {
		bubble.transform.localScale += new Vector3(.01f, .01f, 0);
		if (bubble.transform.localScale.x > 1f) {
			inflating = false;
			bubble.transform.parent = null;
		}
	}
}
