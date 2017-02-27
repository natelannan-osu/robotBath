using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSoapDish : MonoBehaviour {

	public float leftBoundary = -6.94f;
	public float rightBoundary = -2.31f;
	public float minSpeed = 0.001f;
	public float maxSpeed = 0.15f;
	//private int seed;
	private int moveRight;
	private float speed;
	// Use this for initialization
	void Start () {
		moveRight = Random.Range (0, 2);
		//seed = (int)System.DateTime.Now.Ticks;
		//Random.InitState (seed);
		speed = Random.Range (minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (moveRight == 1) {
			if (transform.localPosition.x <= rightBoundary) {  //move left until edge
				transform.Translate (speed, 0f, 0f);  //move left
			} else {
				moveRight = moveRight ^ 1;
			}
		} else {
			if (transform.localPosition.x >= leftBoundary) {  //move left until edge
				transform.Translate (-speed, 0f, 0f);  //move left
			} else {
				moveRight = moveRight ^ 1;
			}
		}
		//Debug.Log ("moveRight: " + moveRight.ToString());
	}
}
