using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehavior : MonoBehaviour {

	public float speed; // we will need to set this upon each level depending on the difficulty settings
	public Rigidbody rb; // Rigidbody for the bar
	public GameObject Dot; // Dot... Will likely need to move when refactoring
	public Rigidbody dotRB; // rigidbody for the dot... again, will likely need to move
	public Vector3 myVector;
	public bool userClicked, hasIntersected;
	public GameObject successMessage;
    Collider m_Collider, m_Collider2;
	public Text text;

	// TODOS
	// [] Get locations of objects
	// [] Move bar based on location of the dot
	// 	-	[] Allow for bar's movement to proceed after passing by the bar
	// [] Get some sort of user input to stop movement -- Bool based on input
	// [] Define a success in terms of the bar's stopping in relation to the dot
	// [] Define movement in regard to angle
	
	// Use this for initialization
	void Start () {
		userClicked = false;
		hasIntersected = false;
		myVector = new Vector3(0.0f, -0.01f, 0.0f);
		rb = GetComponent<Rigidbody>(); // find bar's rigidbody
		dotRB = Dot.GetComponent<Rigidbody>(); // find dot's rigidbody
		dotRB.useGravity = false; // make sure this doesn't fall
		rb.useGravity = false; // also make sure this doesn't fall... will define movement behavior later using the speed based upon the dot's location
		if (Dot != null)
            m_Collider = Dot.GetComponent<Collider>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        m_Collider2 = GetComponent<Collider>();
		text = successMessage.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
			userClicked = true;
        }
		if (!userClicked){
			moveBar();
		}
		if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        {
			hasIntersected = true;
            Debug.Log("Bounds intersecting");
			//text.text = "Text changed!";
        }
		else{
			hasIntersected = false;
		}
		if(userClicked && hasIntersected){
			text.text = "Success!";
		}
		if(userClicked && !hasIntersected){
			text.text = "You missed!";
		}
		
	}

	void moveBar(){
		transform.Translate(myVector);
	}
}
