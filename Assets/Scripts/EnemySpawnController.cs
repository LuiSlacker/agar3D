using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	private GameObject plano1;
	private int enemyCountPlane1;
	private GameObject enemyWrapper;
	private GameObject player;



	public EnemySpawnController(GameObject plano1, GameObject foodWrapper, GameObject player, int foodCountPlane1) {
		this.plano1 = plano1;
		this.enemyCountPlane1 = foodCountPlane1;
		this.enemyWrapper = foodWrapper;
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
			GameObject foodWrapperGO = Instantiate( enemyWrapper , position, Quaternion.identity );
			foodWrapperGO.tag = "enemyWrapper";
			Transform foodGO = foodWrapperGO.transform.GetChild(0);

			float foodWrapperGOScale = Random.Range (1, 4);
			foodWrapperGO.transform.localScale = new Vector3(foodWrapperGOScale, foodWrapperGOScale, foodWrapperGOScale);

			foodWrapperGO.transform.position = new Vector3 ( foodWrapperGO.transform.localPosition.x , (foodWrapperGOScale - 0.7f)/2.0f , foodWrapperGO.transform.localPosition.z );
		}
	}



}
