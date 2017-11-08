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
		InvokeRepeating("findAndSetClosestSmallerGameObject", 0.0f, 2.0f);
	}

	void Update() {
		// set a new object to move to every 2 seconds


		//rotate to look at the object
		Debug.Log(this.objectToMoveTo);
		transform.rotation = (this.objectToMoveTo != null)
			? Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (this.objectToMoveTo.transform.position - transform.position), rotationSpeed * Time.deltaTime)
			: this.randomRotation;

		//move towards the object
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
//		if (other.gameObject.CompareTag ("foodWrapper") || other.gameObject.CompareTag ("enemyWrapper")) {
//			Transform child = other.gameObject.transform.GetChild(0);
//			bool isFoodSmallerThanPlayer = child.gameObject.transform.lossyScale.x < transform.lossyScale.x;
//			Debug.Log ("food: " + child.gameObject.transform.lossyScale.x + " , player: " + transform.lossyScale.x);
//			child.GetComponent<Collider>().isTrigger = isFoodSmallerThanPlayer;
//			Debug.Log ("isTrigger of food set to " + isFoodSmallerThanPlayer);
//		}
//		if (other.gameObject.CompareTag ("food") || other.gameObject.CompareTag ("enemy")) {
//			if(other.transform.localScale.x < this.transform.localScale.x){
//				other.gameObject.SetActive (false);
//				other.transform.parent.gameObject.SetActive (false);
//				transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f,1.1f,1.1f));
//			}
//		}
//
//		if (other.gameObject.CompareTag ("Player")) {
//			Debug.Log ("Player hit");
//			if(other.transform.lossyScale.x < this.transform.GetChild(0).lossyScale.x){
//				other.gameObject.SetActive (false);
//				transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f,1.1f,1.1f));
//				gameOver ();
//			}
//		}
	}

	private void findAndSetClosestSmallerGameObject() {
		float minDistance = float.MaxValue;
		GameObject closestGameObject = null;
		Collider[] colliders = Physics.OverlapSphere(transform.position, 15);
		foreach (Collider collider in colliders) {
			float distanceToOtherObject = getDistanceToOtherObject (collider);
			if(collider.transform.lossyScale.x < this.transform.GetChild(0).lossyScale.x
			&& distanceToOtherObject < minDistance
				&& collider.gameObject != this.gameObject) {
				minDistance = distanceToOtherObject;
				closestGameObject = collider.gameObject;
			}
		}
		this.objectToMoveTo = closestGameObject;
		this.randomRotation = Random.rotation;
	}

	private float getDistanceToOtherObject(Collider collider) {
		return Vector3.Distance (collider.transform.position, this.transform.GetChild (0).position);
	}

	void gameOver() {
		target.gameObject.SetActive (false);
		//gameoverPanel.SetActive (true);
	}
}
