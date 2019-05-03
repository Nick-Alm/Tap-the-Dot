using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class InstructionsScript : MonoBehaviour {

	private FileInfo f;
	public Button resetButton;
	public Button bgButton;

	private bool userClicked;

	// Use this for initialization
	void Start () {
		userClicked = false;
		// GameStats.Level = 1;
		f = new FileInfo(Application.persistentDataPath + "/" + "data.txt");
		Load();
		resetButton.onClick.AddListener(resetClick);
		bgButton.onClick.AddListener(bgClick);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
			userClicked = true;
        }
		if(userClicked){
			//SceneManager.LoadScene (sceneName:"levelOne");
		}
	}

	void resetClick() {
		Debug.Log("Reset clicked");
		StreamWriter w;
		w = f.CreateText();
		GameStats.Level = 1;
		w.Write(GameStats.Level);
		w.Close();
	}

	void bgClick() {
		Debug.Log("bg clicked");
		SceneManager.LoadScene (sceneName:"levelOne");
	}

	void Load() {

		// StreamWriter w;
		Debug.Log(f);

		if(!f.Exists) 
		{
			StreamWriter w;
			w = f.CreateText();
			GameStats.Level = 1;
			w.Write(GameStats.Level);
			w.Close();
		}
		else
		{
			StreamReader r;
			r = f.OpenText();
			string info = r.ReadToEnd();
			r.Close();
			GameStats.Level = int.Parse(info);
			Debug.Log(info);
		}
	}
}
