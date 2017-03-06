using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class popBubble : MonoBehaviour {

	public Text popped;
	private static float popTime = 0.2f;
	private Vector3 prevPos;
	private Rigidbody2D rigidbody;

	[HideInInspector]
	static public int poppedCount = 0;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		popped.text = "Popped: " + poppedCount.ToString ();
		if (poppedCount >= 10 && SceneManager.GetActiveScene().name != "GameOver" && Time.time > popTime) {
			SceneManager.LoadScene (2);
		}
	}

	void FixedUpdate () {
		CheckBubble ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "fans") { 
			popTime = Time.time + 0.2f;
			Destroy (this.gameObject);
			poppedCount++;
		}
	}
	void CheckBubble(){
		if (transform.parent == null && rigidbody.gravityScale != 0f) {  //should be floating
			if (prevPos == transform.position) {
				rigidbody.AddForce (new Vector2 (0f, .0001f)); //give it a little nudge
			}
			prevPos = transform.position; 
		}
	}
}
