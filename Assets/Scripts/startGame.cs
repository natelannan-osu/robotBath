using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		robotControllerScript.lives = 3;
		robotControllerScript.bubbleCount = 0;
		popBubble.poppedCount = 0;
		SceneManager.LoadScene (sceneIndex);
	}
}
