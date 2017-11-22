using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnComenzarController : MonoBehaviour {

	public void onBtnComenzarClick() {
		SceneManager.LoadScene ("game");
	}

	public void gotToInformation() {
		SceneManager.LoadScene ("instruction");
	}

	public void gotToMenu() {
		SceneManager.LoadScene ("menu");
	}

	public void gotToGame() {
		SceneManager.LoadScene ("game");
	}
}
