using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithSoap : MonoBehaviour {
	private Rigidbody2D rigidBody;
	private bool onSoap = false;
	public Transform soapCheck;
	private float soapRadius = 0.2f;
	public LayerMask whatIsSoap;
	private Vector3 offset;
	private GameObject collisionObject;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		offset = new Vector3 (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		onSoap = Physics2D.OverlapCircle(soapCheck.position, soapRadius, whatIsSoap);
		Debug.Log ("onSoap: " + onSoap.ToString ());
		Debug.Log ("offset: " + offset.ToString ());
	}
	void FixedUpdate(){  //physics being used for rocks  fixed update so rocks don't get jostled before drop
		if (onSoap) {
			rigidBody.MovePosition (collisionObject.transform.position + offset);  //move rock with claw
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "soap") { 
			offset = transform.position - other.gameObject.transform.position;
			collisionObject = other.gameObject;
		}
	}
}
