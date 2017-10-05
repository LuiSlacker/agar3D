using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject plano1;
	public int foodCountPlane1;
	public GameObject foodWrapper;
	public GameObject player;

	public FoodController foodController;

	// Use this for initialization
	void Start () {
		foodController = new FoodController (plano1, foodWrapper, player, foodCountPlane1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
