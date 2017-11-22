using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	public GameObject plano1;
	public GameObject plano2;
	public GameObject plano3;
	public int enemyCountPlane1;
	public int enemyCountPlane2;
	public int enemyCountPlane3;
	public GameObject enemy;
	public GameObject player;

	void Start() {
		populateEnemiesPlane1 ();
	}


//	public EnemySpawnController(GameObject plano1, GameObject enemy, GameObject player, int foodCountPlane1) {
//		this.plano1 = plano1;
//		this.enemyCountPlane1 = foodCountPlane1;
//		this.enemy = enemy;
//		this.player = player;
//
//		populateEnemies ();
//	}

	void populateEnemiesPlane1 () {

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

	public void populateEnemiesPlane2 () {

		Bounds P02 = this.plano2.GetComponent<Renderer> ().bounds;

		float P2x  = this.plano2.transform.position.x + P02.size.x/2;
		float P2_x = this.plano2.transform.position.x - P02.size.x/2;
		float P2y  = 0.2f;
		float P2z  = this.plano2.transform.position.z + P02.size.z/2;
		float P2_z = this.plano2.transform.position.z - P02.size.z/2;

		for (int i = 0 ; i < enemyCountPlane2; i++) {
			Vector3 position = new Vector3(Random.Range(P2_x, P2x), P2y, Random.Range(P2_z, P2z));
			GameObject enemyGO = Instantiate( enemy , position, Quaternion.identity );
			enemyGO.tag = "enemy";
			float enemyGOScale = Random.Range (0.2f, 1.1f);
			enemyGO.transform.localScale = new Vector3(enemyGOScale, enemyGOScale, enemyGOScale);

			// make sure enemy is put on the floor
			enemyGO.transform.position = new Vector3 ( enemyGO.transform.localPosition.x , (enemyGOScale)/2.0f , enemyGO.transform.localPosition.z );
		}
	}

	public void populateEnemiesPlane3 () {

		Bounds P03 = this.plano3.GetComponent<Renderer> ().bounds;

		float P3x  = this.plano3.transform.position.x + P03.size.x/2;
		float P3_x = this.plano3.transform.position.x - P03.size.x/2;
		float P3y  = 0.2f;
		float P3z  = this.plano3.transform.position.z + P03.size.z/2;
		float P3_z = this.plano3.transform.position.z - P03.size.z/2;

		for (int i = 0 ; i < enemyCountPlane3; i++) {
			Vector3 position = new Vector3(Random.Range(P3_x, P3x), P3y, Random.Range(P3_z, P3z));
			GameObject enemyGO = Instantiate( enemy , position, Quaternion.identity );
			enemyGO.tag = "enemy";
			float enemyGOScale = Random.Range (0.2f, 1.1f);
			enemyGO.transform.localScale = new Vector3(enemyGOScale, enemyGOScale, enemyGOScale);

			// make sure enemy is put on the floor
			enemyGO.transform.position = new Vector3 ( enemyGO.transform.localPosition.x , (enemyGOScale)/2.0f , enemyGO.transform.localPosition.z );
		}
	}


}
