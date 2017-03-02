using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class popBubble : MonoBehaviour {

	public Text popped;
	private static float popTime = 0.2f;

	[HideInInspector]
	static public int poppedCount = 0;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		popped.text = "Popped: " + poppedCount.ToString ();
		if (poppedCount >= 10 && SceneManager.GetActiveScene().name != "GameOver" && Time.time > popTime) {
			//poppedCount = 0;
			//robotControllerScript.lives = 3;
			SceneManager.LoadScene (2);
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "fans") { 
			popTime = Time.time + 0.2f;
			Debug.Log("time: " + Time.time.ToString() + "popTime: " + popTime.ToString());
			Destroy (this.gameObject);
			poppedCount++;

		}
	}
}
