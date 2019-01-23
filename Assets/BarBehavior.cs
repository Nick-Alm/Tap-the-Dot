using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehavior : MonoBehaviour {

	public float speed; // we will need to set this upon each level depending on the difficulty settings
	public Rigidbody rb; // Rigidbody for the bar
	public GameObject Dot; // Dot... Will likely need to move when refactoring
	public Rigidbody dotRB; // rigidbody for the dot... again, will likely need to move

	// TODOS
	// [] Get locations of objects
	// [] Move bar based on location of the dot
	// 	-	[] Allow for bar's movement to proceed after passing by the bar
	// [] Get some sort of user input to stop movement -- Bool based on input
	// [] Define a success in terms of the bar's stopping in relation to the dot
	// [] Define movement in regard to angle
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>(); // find bar's rigidbody
		dotRB = Dot.GetComponent<Rigidbody>(); // find dot's rigidbody
		dotRB.useGravity = false; // make sure this doesn't fall
		rb.useGravity = false; // also make sure this doesn't fall... will define movement behavior later using the speed based upon the dot's location
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
