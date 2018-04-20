using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 8f;
	public float jumpSpeed = 7f;

	Rigidbody rb;
	Collider coll;

	bool jumpPressed = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		// Walking
		float distance = walkSpeed * Time.deltaTime;
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (hAxis * distance, 0f, vAxis * distance);
		Vector3 curPosition = transform.position;
		Vector3 newPosition = curPosition + movement;
		rb.MovePosition (newPosition);

		// Jumping
		float jAxis = Input.GetAxis("Jump");
		bool isGrounded = CheckGrounded ();

		if (jAxis > 0f) {
			if (!jumpPressed && isGrounded) {
				jumpPressed = true;
				Vector3 jumpVector = new Vector3 (0f, jumpSpeed, 0f);
				rb.velocity = rb.velocity + jumpVector;
			}
		} else {
			jumpPressed = false;
		}
	}

	bool CheckGrounded() {
		float sizeX = coll.bounds.size.x;
		float sizeY = coll.bounds.size.y;
		float sizeZ = coll.bounds.size.z;

		Vector3 corner1 = transform.position + new Vector3 (sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
		Vector3 corner2 = transform.position + new Vector3 (-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
		Vector3 corner3 = transform.position + new Vector3 (sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
		Vector3 corner4 = transform.position + new Vector3 (-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
	
		bool grounded1 = Physics.Raycast (corner1, new Vector3 (0, -1, 0), 0.01f);
		bool grounded2 = Physics.Raycast (corner2, new Vector3 (0, -1, 0), 0.01f);
		bool grounded3 = Physics.Raycast (corner3, new Vector3 (0, -1, 0), 0.01f);
		bool grounded4 = Physics.Raycast (corner4, new Vector3 (0, -1, 0), 0.01f);

		return (grounded1 || grounded2 || grounded3 || grounded4);

	}
}
