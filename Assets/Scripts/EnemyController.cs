using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	public GameObject gameoverPanel;
	private int rotationSpeed = 2;
	private int moveSpeed = 2;


	private GameObject objectToMoveTo;
	private Quaternion randomRotation;


	void Start () {
		target = GameObject.FindWithTag("Player").transform; //target the player

		// set a new object to move to every 2 seconds
		InvokeRepeating("findAndSetClosestSmallerGameObject", 0.0f, 2.0f);
	}

	void Update() {

		if (this.objectToMoveTo != null) {
			//rotate to look at the object
			Vector3 positionToMoveTo = this.objectToMoveTo.transform.position;
			positionToMoveTo.y = transform.position.y;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (positionToMoveTo - transform.position), rotationSpeed * Time.deltaTime);
		} else {
			transform.rotation = this.randomRotation;
		}

		//move towards the object
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("foodWrapper")) {
			Transform child = other.gameObject.transform.GetChild (0);
			bool isFoodSmallerThanMe = child.gameObject.transform.lossyScale.x < transform.lossyScale.x;
			Debug.Log ("food: " + child.gameObject.transform.lossyScale.x + " , player: " + transform.lossyScale.x);
			child.GetComponent<Collider> ().isTrigger = isFoodSmallerThanMe;
			Debug.Log ("isTrigger of food set to " + isFoodSmallerThanMe);
		} else if (other.gameObject.CompareTag ("food")) {
			if (other.transform.localScale.x < this.transform.localScale.x) {
				other.gameObject.SetActive (false);
				other.transform.parent.gameObject.SetActive (false);
				transform.localScale = Vector3.Scale (transform.localScale, new Vector3 (1.1f, 1.1f, 1.1f));
				putOnTheGround ();
			}
		} else if (other.gameObject.CompareTag ("Player")) {
			if (other.transform.lossyScale.x < this.transform.lossyScale.x) {
				other.gameObject.SetActive (false);
				transform.localScale = Vector3.Scale (transform.localScale, new Vector3 (1.1f, 1.1f, 1.1f));
				putOnTheGround ();
			}
		} else if (other.gameObject.CompareTag ("enemy")) {
			if (other.transform.localScale.x < this.transform.localScale.x) {
				other.gameObject.SetActive (false);
				transform.localScale = Vector3.Scale (transform.localScale, new Vector3 (1.1f, 1.1f, 1.1f));
				putOnTheGround ();
			}
		}
	}

	private void putOnTheGround() {
		transform.position = new Vector3 (transform.position.x, transform.lossyScale.x / 2, transform.position.z);
	}

	private void findAndSetClosestSmallerGameObject() {
		float minDistance = float.MaxValue;
		GameObject closestGameObject = null;
		Collider[] colliders = Physics.OverlapSphere(transform.position, 15);
		foreach (Collider collider in colliders) {
			float distanceToOtherObject = getDistanceToOtherObject (collider);
			if(collider.transform.lossyScale.x < this.transform.lossyScale.x
			&& distanceToOtherObject < minDistance
			&& collider.gameObject != this.gameObject) {
				Debug.Log("new closet player set");
				minDistance = distanceToOtherObject;
				closestGameObject = collider.gameObject;
			}
		}
		this.objectToMoveTo = closestGameObject;
		Quaternion newRotation = Random.rotation;
		newRotation.y = this.transform.position.y;
		this.randomRotation = newRotation;
	}

	private float getDistanceToOtherObject(Collider collider) {
		return Vector3.Distance (collider.transform.position, this.transform.position);
	}

	void gameOver() {
		target.gameObject.SetActive (false);
		//gameoverPanel.SetActive (true);
	}
}
