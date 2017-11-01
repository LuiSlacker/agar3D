using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject target;
	public GameObject puerta01, puerta02;
	public int NumEnemy;

	private int enemyCount;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 10;
	}

	void Update () {
		if(enemyCount == NumEnemy) { // abrir puerta 01
			puerta01.SetActive (false);
		}
		if(enemyCount == NumEnemy * 2) { // abrir puerta 02
			puerta01.SetActive (true);
			puerta02.SetActive (false);
		}
	}

	void FixedUpdate() {
		rb.AddForce(Input.GetAxis("Vertical") * target.transform.forward * speed);
		rb.AddForce(Input.GetAxis("Horizontal") * target.transform.right * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("foodWrapper") || other.gameObject.CompareTag ("enemyWrapper")) {
			Transform child = other.gameObject.transform.GetChild(0);
			bool isFoodSmallerThanPlayer = child.gameObject.transform.lossyScale.x < transform.lossyScale.x;
			Debug.Log ("food: " + child.gameObject.transform.lossyScale.x + " , player: " + transform.lossyScale.x);
			child.GetComponent<Collider>().isTrigger = isFoodSmallerThanPlayer;
			Debug.Log ("isTrigger of food set to " + isFoodSmallerThanPlayer);
		}
		if (other.gameObject.CompareTag ("food") || other.gameObject.CompareTag ("enemy")) {
			if(other.transform.localScale.x < this.transform.localScale.x){
				other.gameObject.SetActive (false);
				other.transform.parent.gameObject.SetActive (false);
				enemyCount++;
				transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f,1.1f,1.1f));
			}
		}
	}
}
