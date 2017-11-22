using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject target;
	public GameObject puerta01, puerta02;
	public int NumEnemy;
	public GameObject gameoverPanel;

	private FoodSpawnController foodSpawnController;
	private EnemySpawnController enemySpawnController;
	public GameObject foodSpawn;
	public GameObject enemySpawn;

	private int enemyCount;

	private Rigidbody rb;

	private bool plane2Spawned = false;
	private bool plane3Spawned = false;

	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 10;

		foodSpawnController = foodSpawn.GetComponent<FoodSpawnController>();
		enemySpawnController = enemySpawn.GetComponent<EnemySpawnController>();
	}

	void Update () {
		if(enemyCount >= NumEnemy) { // abrir puerta 01
			puerta01.SetActive (false);
			if (!plane2Spawned) {
				foodSpawnController.populateFoodPlane2 ();
				enemySpawnController.populateEnemiesPlane2 ();
				plane2Spawned = true;
			}
		}
		if(enemyCount >= NumEnemy * 2) { // abrir puerta 02
			puerta02.SetActive (false);
			if (!plane3Spawned) {
				foodSpawnController.populateFoodPlane3 ();
				enemySpawnController.populateEnemiesPlane3 ();
				plane3Spawned = true;
			}
		}
	}

	void FixedUpdate() {
		rb.AddForce(Input.GetAxis("Vertical") * target.transform.forward * speed);
		rb.AddForce(Input.GetAxis("Horizontal") * target.transform.right * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("foodWrapper")) {
			Transform child = other.gameObject.transform.GetChild(0);
			bool isFoodSmallerThanPlayer = child.gameObject.transform.lossyScale.x < transform.lossyScale.x;
			Debug.Log ("food: " + child.gameObject.transform.lossyScale.x + " , player: " + transform.lossyScale.x);
			child.GetComponent<Collider>().isTrigger = isFoodSmallerThanPlayer;
			Debug.Log ("isTrigger of food set to " + isFoodSmallerThanPlayer);
		} else if (other.gameObject.CompareTag ("food")) {
			if(other.transform.localScale.x < this.transform.localScale.x){
				other.gameObject.SetActive (false);
				other.transform.parent.gameObject.SetActive (false);
				enemyCount++;
				transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f,1.1f,1.1f));
			}
		} else if (other.gameObject.CompareTag ("enemy")) {
			if (other.transform.localScale.x < this.transform.localScale.x) {
				other.gameObject.SetActive (false);
				enemyCount++;
				transform.localScale = Vector3.Scale (transform.localScale, new Vector3 (1.1f, 1.1f, 1.1f));
			} else {
				gameOver ();
			}
		}
	}

	void gameOver() {
		gameoverPanel.SetActive (true);
	}
}