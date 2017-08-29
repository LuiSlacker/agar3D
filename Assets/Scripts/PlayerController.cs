using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject target;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 10;
	}

	void Update () {
		
	}

	void FixedUpdate() {
		rb.AddForce(Input.GetAxis("Vertical") * target.transform.forward * speed);
		rb.AddForce(Input.GetAxis("Horizontal") * target.transform.right * speed);
	}
}
