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

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("enemy")) {
			other.gameObject.SetActive (false);
			transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f,1.1f,1.1f));
		}
	}
}
