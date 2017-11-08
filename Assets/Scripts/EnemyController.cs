using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	public GameObject gameoverPanel;
	private int rotationSpeed = 2;
	private int moveSpeed = 2;


	void Start () {
		target = GameObject.FindWithTag("Player").transform; //target the player
	}

	void Update() {
		//rotate to look at the player
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

		//move towards the player
		bool isPlayerSmallerThanEnemy = target.lossyScale.x < transform.GetChild(0).lossyScale.x;
		if (isPlayerSmallerThanEnemy) {
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
  		}
	}

//	void OnTriggerEnter(Collider other) {
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
//	}

	void gameOver() {
		target.gameObject.SetActive (false);
		//gameoverPanel.SetActive (true);
	}
}
