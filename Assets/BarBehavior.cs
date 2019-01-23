using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehavior : MonoBehaviour {

	public float speed;
	public Rigidbody rb;
	public GameObject Dot;
	public Rigidbody dotRB;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		dotRB = Dot.GetComponent<Rigidbody>();
		dotRB.useGravity = false;
		rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
