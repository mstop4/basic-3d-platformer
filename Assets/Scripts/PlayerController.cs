using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 8f;
	public float jumpSpeed = 7f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = walkSpeed * Time.deltaTime;
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (hAxis * distance, 0f, vAxis * distance);
		Vector3 curPosition = transform.position;
		Vector3 newPosition = curPosition + movement;
		rb.MovePosition (newPosition);
	}
}
