using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;


public class BetweenLevelScript : MonoBehaviour {

	private FileInfo f;

	private bool userClicked;

	// Use this for initialization
	void Start () {
		userClicked = false;

		UpdateLevelInfo();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
			userClicked = true;
        }
		if(userClicked){
			SceneManager.LoadScene (sceneName:"levelOne");
		}
	}

	void UpdateLevelInfo() {
		f = new FileInfo(Application.persistentDataPath + "/" + "data.txt");
	
		StreamWriter w;

		w = f.CreateText();
		w.Write(GameStats.Level);
		w.Close();
	}
}
