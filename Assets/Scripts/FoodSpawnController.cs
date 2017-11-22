using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnController : MonoBehaviour {

	public GameObject plano1;
	public GameObject plano2;
	public GameObject plano3;
	public int foodCountPlane1;
	public int foodCountPlane2;
	public int foodCountPlane3;
	public GameObject foodWrapper;
	public GameObject player;

	void Start() {
		InvokeRepeating("populateFoodPlane1", 0.0f, 10f);
	}		

	private void populateFoodPlane1 () {
		Bounds P01 = this.plano1.GetComponent<Renderer> ().bounds;
		float P1x  = this.plano1.transform.position.x + P01.size.x/2;
		float P1_x = this.plano1.transform.position.x - P01.size.x/2;
		float P1y  = 0.2f;
		float P1z  = this.plano1.transform.position.z + P01.size.z/2;
		float P1_z = this.plano1.transform.position.z - P01.size.z/2;

		for (int i = 0 ; i < foodCountPlane1; i++) {
			Vector3 position = new Vector3(Random.Range(P1_x, P1x), P1y, Random.Range(P1_z, P1z));
			GameObject foodWrapperGO = Instantiate( foodWrapper , position, Quaternion.identity );
			foodWrapperGO.tag = "foodWrapper";

			float foodWrapperGOScale = Random.Range (1, 3);
			foodWrapperGO.transform.localScale = new Vector3(foodWrapperGOScale, foodWrapperGOScale, foodWrapperGOScale);

			Transform food = foodWrapperGO.transform.GetChild(0);
			foodWrapperGO.transform.position = new Vector3 ( foodWrapperGO.transform.localPosition.x , (food.transform.lossyScale.x)/2.0f , foodWrapperGO.transform.localPosition.z );
		}
	}

	public void populateFoodPlane2 () {
		Bounds P02 = this.plano2.GetComponent<Renderer> ().bounds;
		float P2x  = this.plano2.transform.position.x + P02.size.x/2;
		float P2_x = this.plano2.transform.position.x - P02.size.x/2;
		float P2y  = 0.2f;
		float P2z  = this.plano2.transform.position.z + P02.size.z/2;
		float P2_z = this.plano2.transform.position.z - P02.size.z/2;

		for (int i = 0 ; i < foodCountPlane2; i++) {
			Debug.Log(foodCountPlane2);
			Vector3 position = new Vector3(Random.Range(P2_x, P2x), P2y, Random.Range(P2_z, P2z));
			GameObject foodWrapperGO = Instantiate( foodWrapper , position, Quaternion.identity );
			foodWrapperGO.tag = "foodWrapper";

			float foodWrapperGOScale = Random.Range (1, 3);
			foodWrapperGO.transform.localScale = new Vector3(foodWrapperGOScale, foodWrapperGOScale, foodWrapperGOScale);

			Transform food = foodWrapperGO.transform.GetChild(0);
			foodWrapperGO.transform.position = new Vector3 ( foodWrapperGO.transform.localPosition.x , (food.transform.lossyScale.x)/2.0f , foodWrapperGO.transform.localPosition.z );
		}
	}

	public void populateFoodPlane3 () {
		Bounds P03 = this.plano3.GetComponent<Renderer> ().bounds;
		float P3x  = this.plano3.transform.position.x + P03.size.x/2;
		float P3_x = this.plano3.transform.position.x - P03.size.x/2;
		float P3y  = 0.2f;
		float P3z  = this.plano3.transform.position.z + P03.size.z/2;
		float P3_z = this.plano3.transform.position.z - P03.size.z/2;

		for (int i = 0 ; i < foodCountPlane2; i++) {
			Vector3 position = new Vector3(Random.Range(P3_x, P3x), P3y, Random.Range(P3_z, P3z));
			GameObject foodWrapperGO = Instantiate( foodWrapper , position, Quaternion.identity );
			foodWrapperGO.tag = "foodWrapper";

			float foodWrapperGOScale = Random.Range (1, 3);
			foodWrapperGO.transform.localScale = new Vector3(foodWrapperGOScale, foodWrapperGOScale, foodWrapperGOScale);

			Transform food = foodWrapperGO.transform.GetChild(0);
			foodWrapperGO.transform.position = new Vector3 ( foodWrapperGO.transform.localPosition.x , (food.transform.lossyScale.x)/2.0f , foodWrapperGO.transform.localPosition.z );
		}
	}

}
