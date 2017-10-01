﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public GameObject Enemy ;
	public GameObject plano1 ,plano2 ,plano3;
	public int NumberEnemyPlane1 , NumberEnemyPlane2, NumberEnemyPlane3;

	void Start () {
		
		Bounds P01 = this.plano1.GetComponent<Renderer> ().bounds;
		Bounds P02 = this.plano2.GetComponent<Renderer> ().bounds;
		Bounds P03 = this.plano3.GetComponent<Renderer> ().bounds;

		float P1x  = this.plano1.transform.position.x + P01.size.x/2;
		float P1_x = this.plano1.transform.position.x - P01.size.x/2;
		float P1y  = 0.2f;
		float P1z  = this.plano1.transform.position.z + P01.size.z/2;
		float P1_z = this.plano1.transform.position.z - P01.size.z/2;


		float P2x  = this.plano2.transform.position.x + P02.size.x/2;
		float P2_x = this.plano2.transform.position.x - P02.size.x/2;
		float P2y  = 0.2f;
		float P2z  = this.plano2.transform.position.z + P02.size.z/2;
		float P2_z = this.plano2.transform.position.z - P02.size.z/2;


		float P3x  = this.plano3.transform.position.x + P03.size.x/2;
		float P3_x = this.plano3.transform.position.x - P03.size.x/2;
		float P3y  = 0.2f;
		float P3z  = this.plano3.transform.position.z + P03.size.z/2;
		float P3_z = this.plano3.transform.position.z - P03.size.z/2;

		//Vector3 P1 = new Vector3 (P1x,P1y,P1z);
		//Vector3 P2 = new Vector3 (P2x,P2y,P2z);
		//Vector3 P3 = new Vector3 (P3x,P3y,P3z);

		Debug.Log ("plano1: " + "P1x("+ P1_x +" ; "+ P1x +")" + "P1y(0)" + "P1z("+ P1_z +" ; "+ P1z +")" );
		Debug.Log ("plano2: " + "P2x("+ P2_x +" ; "+ P2x +")" + "P2y(0)" + "P2z("+ P2_z +" ; "+ P2z +")" );
		Debug.Log ("plano3: " + "P3x("+ P3_x +" ; "+ P3x +")" + "P3y(0)" + "P3z("+ P3_z +" ; "+ P3z +")" );

		for(int i = 0 ; i < NumberEnemyPlane1; i++ ){
			Vector3 position = new Vector3(Random.Range(P1_x, P1x), P1y, Random.Range(P1_z, P1z));
			GameObject gm = Instantiate( Enemy , position, Quaternion.identity );
			gm.tag = "enemy";

			float rd = Random.Range ( 0 , 2 );
			rd = rd + Random.value;
			gm.transform.localScale = new Vector3(rd,rd,rd);
			gm.transform.position = new Vector3 ( gm.transform.localPosition.x , (rd /2) , gm.transform.localPosition.z );

			Debug.Log ("enemy# "+ i +", plano1: " + position );
		}

		for(int i = 0 ; i < NumberEnemyPlane2; i++ ){
			Vector3 position = new Vector3(Random.Range(P2_x, P2x), P2y, Random.Range(P2_z, P2z));
			GameObject gm = Instantiate( Enemy , position, Quaternion.identity );
			gm.tag = "enemy";

			float rd = Random.Range ( 0 , 2 );
			rd = rd + Random.value;
			gm.transform.localScale = new Vector3(rd,rd,rd);
			gm.transform.position = new Vector3 ( gm.transform.localPosition.x , (rd /2) , gm.transform.localPosition.z );


			Debug.Log ("enemy# "+ i +", plano2: " + position );
		}

		for(int i = 0 ; i < NumberEnemyPlane3; i++ ){
			Vector3 position = new Vector3(Random.Range(P3_x, P3x), P3y, Random.Range(P3_z, P3z));
			GameObject gm = Instantiate( Enemy , position, Quaternion.identity );
			gm.tag = "enemy";

			float rd = Random.Range ( 0 , 2 );
			rd = rd + Random.value;
			gm.transform.localScale = new Vector3(rd,rd,rd);
			gm.transform.position = new Vector3 ( gm.transform.localPosition.x , (rd /2) , gm.transform.localPosition.z );

			Debug.Log ("enemy# "+ i +", plano3: " + position );
		}


	}

	void Update () {
		
	}
}
