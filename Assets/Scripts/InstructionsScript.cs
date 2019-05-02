using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InstructionsScript : MonoBehaviour {

	private bool userClicked;

	// Use this for initialization
	void Start () {
		userClicked = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
			userClicked = true;
        }
		if(userClicked){
			SceneManager.LoadScene (sceneName:"introScene");
		}
	}
}
