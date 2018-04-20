using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 8f;
	public float jumpSpeed = 7f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float hAxis = Input.GetAxis ("Horizontal");
		print ("Horizontal axis");
		print (hAxis);

		float vAxis = Input.GetAxis ("Vertical");
		print ("Vertical axis");
		print (vAxis);
	}
}
