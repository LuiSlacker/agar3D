using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject plano1;
	public GameObject player;

	public int foodCountPlane1;
	public int enemyCountPlane1;

	public GameObject foodWrapper;
	public GameObject enemyWrapper;

	public FoodSpawnController foodSpawnController;
	public EnemySpawnController enemySpawnController;

	// Use this for initialization
	void Start () {
		foodSpawnController = new FoodSpawnController (plano1, foodWrapper, player, foodCountPlane1);
		enemySpawnController = new EnemySpawnController (plano1, enemyWrapper, player, enemyCountPlane1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
