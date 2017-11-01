using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	private int rotationSpeed = 2;
	private int moveSpeed = 2;


	void Start () {
		target = GameObject.FindWithTag("Player").transform; //target the player
	}

	void Update() {
		//rotate to look at the player
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

		//move towards the player
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}
