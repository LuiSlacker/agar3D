using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject plano1;
	public GameObject plano2;
	public GameObject plano3;
	public GameObject player;

	public int foodCountPlane1;
	public int foodCountPlane2;
	public int foodCountPlane3;
	public int enemyCountPlane1;

	public GameObject foodWrapper;
	public GameObject enemy;

	public FoodSpawnController foodSpawnController;
	public EnemySpawnController enemySpawnController;

	// Use this for initialization
	void Start () {
//		foodSpawnController = new FoodSpawnController (plano1, plano2, plano3, foodWrapper, player, foodCountPlane1, foodCountPlane2, foodCountPlane3);
//		enemySpawnController = new EnemySpawnController (plano1, enemy, player, enemyCountPlane1);
	}

}
