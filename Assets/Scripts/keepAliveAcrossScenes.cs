using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepAliveAcrossScenes : MonoBehaviour {
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}
