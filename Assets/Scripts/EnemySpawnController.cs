using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	private GameObject plano1;
	private int enemyCountPlane1;
	private GameObject enemy;
	private GameObject player;



	public EnemySpawnController(GameObject plano1, GameObject enemy, GameObject player, int foodCountPlane1) {
		this.plano1 = plano1;
		this.enemyCountPlane1 = foodCountPlane1;
		this.enemy = enemy;
		this.player = player;

		populateEnemies ();
	}

	void populateEnemies () {

		Bounds P01 = this.plano1.GetComponent<Renderer> ().bounds;

		float P1x  = this.plano1.transform.position.x + P01.size.x/2;
		float P1_x = this.plano1.transform.position.x - P01.size.x/2;
		float P1y  = 0.2f;
		float P1z  = this.plano1.transform.position.z + P01.size.z/2;
		float P1_z = this.plano1.transform.position.z - P01.size.z/2;

		for (int i = 0 ; i < enemyCountPlane1; i++) {
			Vector3 position = new Vector3(Random.Range(P1_x, P1x), P1y, Random.Range(P1_z, P1z));
			GameObject enemyGO = Instantiate( enemy , position, Quaternion.identity );
			enemyGO.tag = "enemy";
			float enemyGOScale = Random.Range (0.2f, 1.1f);
			enemyGO.transform.localScale = new Vector3(enemyGOScale, enemyGOScale, enemyGOScale);

			// make sure enemy is put on the floor
			enemyGO.transform.position = new Vector3 ( enemyGO.transform.localPosition.x , (enemyGOScale)/2.0f , enemyGO.transform.localPosition.z );
		}
	}



}
