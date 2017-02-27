using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	private bool facingRight = true;
	private Rigidbody2D rigidBody;
	private float move;
	private Animator animator;
	private bool grounded = false;
	private bool inTub = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	private bool onSoap = false;
	public Transform soapCheck;
	public LayerMask whatIsSoap;
	public LayerMask whatIsTub;
	private GameObject collisionObject;
	private int bubbleCount;
	private spawnBubble bubbles;
//	private float leftBorder = -7.69f;
//	private float rightBorder = 7.71f;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		//collisionObject = this.gameObject;
		transform.parent = null;
//		bubbleCount = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!inTub) {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			inTub = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsTub);
			animator.SetBool ("Ground", grounded);
			animator.SetFloat ("vSpeed", rigidBody.velocity.y);
			animator.SetBool ("InTub", inTub);

			move = Input.GetAxis ("Horizontal");
			animator.SetFloat ("speed", Mathf.Abs (move));
			rigidBody.velocity = new Vector2 (move * maxSpeed, rigidBody.velocity.y);
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();

		}
	}

	void Update(){
		if (!inTub) {
			onSoap = Physics2D.OverlapCircle (soapCheck.position, groundRadius, whatIsSoap);
			if (onSoap) {
				transform.parent = collisionObject.transform;
			} else {
				transform.parent = null;
			}
			if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown ("Fire1"))) {
				animator.SetBool ("Ground", false);
				rigidBody.AddForce (new Vector2 (0, jumpForce));
			}
			//Debug.Log ("grounded: " + grounded.ToString () + " onSoap: " + onSoap.ToString ());
			if (transform.parent != null) {
			}
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "soap") { 
			collisionObject = other.gameObject;
		}
		if (other.gameObject.CompareTag ("bubble")) {
			bubbleCount++;
			other.gameObject.SetActive (false);
			//Destroy (other.gameObject);
			Debug.Log ("Bubble Score: " + bubbleCount.ToString());
		}
	}

//	void OnTriggerEnter2D(Collider2D other) {  //2d collider that has been touched
//		if (other.gameObject.CompareTag ("bubble")) {
//			other.gameObject.SetActive (false);  // if pickup collision, deactivate pickup
//			bubbleCount++;
//			//SetCountText ();
//		}
//	}
}
