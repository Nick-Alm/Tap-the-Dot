using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarBehavior : MonoBehaviour {

	private Vector3 startPosition, currentPosition;
	public float speed; // we will need to set this upon each level depending on the difficulty settings
	public Rigidbody rb; // Rigidbody for the bar
	public GameObject Dot; 
	public Rigidbody dotRB; 
	public Vector3 movementVector;
	public bool userClicked, hasIntersected, userFailedToClick, successTap;
	public GameObject successMessage, currentLevelDisplay, dotsRemainingDisplay;
    Collider m_Collider, m_Collider2;
	public Text successText, currentLevelText, dotsRemainingText;
	private int successDelay = 2;
	private DotBehavior dotBehavior;
	private int currentLevel, currentLevelDots;
	private int levelOneDots, levelTwoDots, levelThreeDots;

	// Use this for initialization
	void Start () {
		startPosition = new Vector3(0.0f, 5.15f, 5.5f);
		userFailedToClick = false;
		userClicked = false;
		hasIntersected = false;
		movementVector = new Vector3(0.0f, -0.1f, 0.0f);

		rb = GetComponent<Rigidbody>(); // find bar's rigidbody
		dotRB = Dot.GetComponent<Rigidbody>(); // find dot's rigidbody
		dotRB.useGravity = false; // make sure this doesn't fall
		rb.useGravity = false; // also make sure this doesn't fall... will define movement behavior later using the speed based upon the dot's location

		if (Dot != null)
            m_Collider = Dot.GetComponent<Collider>();
			dotBehavior = Dot.GetComponent<DotBehavior>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        m_Collider2 = GetComponent<Collider>();
		successText = successMessage.GetComponent<Text>();
		currentLevelText = currentLevelDisplay.GetComponent<Text>();
		dotsRemainingText = dotsRemainingDisplay.GetComponent<Text>();
		// currentLevelText.text = '1';

		currentLevelDots = GameStats.Level*2 + 3;
		dotsRemainingText.text = currentLevelDots.ToString();
		currentLevel = GameStats.Level;
		currentLevelText.text = currentLevel.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		currentPosition = transform.position;

		if(currentPosition[1]<-5.5){
			Debug.Log("failed to click");
			userFailedToClick =  true;
			successText.text = "You Failed to Tap";
		}

		if (Input.GetButton("Fire1"))
        {
			userClicked = true;
        }
		if (!userClicked && !userFailedToClick){
			moveBar();
		}
		if (checkCollision())
        {
			hasIntersected = true;
            //Debug.Log("Bounds intersecting");
			//successText.text = "Text changed!";
        }
		else{
			hasIntersected = false;
		}


		if(userClicked && hasIntersected){
			successTap = true;
			StartCoroutine(successFrame());
		}
		if(userClicked && !hasIntersected){
			if(!successTap){
				successText.text = "You missed!";
				if(currentLevel ==1) {
					currentLevelDots = levelOneDots;
				}
				if(currentLevel ==2) {
					currentLevelDots = levelTwoDots;
				}
				if(currentLevel ==3) {
					currentLevelDots = levelThreeDots;
				}
				SceneManager.LoadScene (sceneName:"Main");
				dotsRemainingText.text = currentLevelDots.ToString();
			}
		}
		
	}

	void moveBar(){
		transform.Translate(movementVector);
	}

	private bool checkCollision(){
		return m_Collider.bounds.Intersects(m_Collider2.bounds);
	}

	IEnumerator successFrame(){
		transform.position = startPosition;
		successText.text = "Success!";
		currentLevelDots--;
		if(currentLevelDots<1) {
			if(currentLevel == 1) {
				currentLevelDots = levelTwoDots;
				movementVector = new Vector3(0.0f, -0.15f, 0.0f);
			} else if (currentLevel == 2) {
				currentLevelDots = levelThreeDots;
				movementVector = new Vector3(0.0f, -0.2f, 0.0f);
			}
			currentLevel ++;
			GameStats.Level++;
			SceneManager.LoadScene (sceneName:"betweenLevels");
		}
		currentLevelText.text = currentLevel.ToString();
		dotsRemainingText.text = currentLevelDots.ToString();
		Debug.Log("waiting...");
		yield return new WaitForSecondsRealtime(successDelay);
		successTap = false;
		successText.text = "";
		userClicked = false;
		dotBehavior.resetLocation();

		Debug.Log("waited");
	}
}
