using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayEndScreen : MonoBehaviour {
	public Text score;
	public Text highScore;
	public Text causeForEnd;
	private static int oldHighScore = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (robotControllerScript.lives == 0) {
			causeForEnd.text = "Ran out of lives";

		} else if (popBubble.poppedCount == 10) {
			causeForEnd.text = "Ten bubbles popped";
		} else {
			causeForEnd.text = "Bugness.  Sad face.";
		}
		if (robotControllerScript.bubbleCount > oldHighScore) {
			highScore.text = "High Score: " + robotControllerScript.bubbleCount.ToString ();
			oldHighScore = robotControllerScript.bubbleCount;
		} else {
			highScore.text = "High Score: " + oldHighScore.ToString ();
		}
		score.text = "Your Score: " + robotControllerScript.bubbleCount.ToString ();
	}
}
