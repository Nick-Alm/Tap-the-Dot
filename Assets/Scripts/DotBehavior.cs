using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DotBehavior : MonoBehaviour {

	private Vector3 spherePosition;

	// Use this for initialization
	void Start () {
		resetLocation();
	}

	private float getRandomX(){
		double minimum = -11.5f;
		double maximum = minimum * -1.0;
		System.Random random = new System.Random();
    	return (float)(random.NextDouble() * (maximum - minimum) + minimum);
		//return 2.0f;
	}

	private float getRandomY(){
		double minimum = -4.5f;
		double maximum = minimum * -1.0;
		System.Random random = new System.Random();
    	return (float)(random.NextDouble() * (maximum - minimum) + minimum);
		//return 2.0f;
	}

	public void resetLocation(){
		spherePosition = new Vector3(getRandomX(), getRandomY(), 5.5f);
		transform.position = spherePosition;
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
