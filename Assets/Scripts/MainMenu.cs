using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button playButton;
	public Button quitButton;
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

	// Use this for initialization
	void Start () {
		playButton.onClick.AddListener(PlayMaze);
		quitButton.onClick.AddListener(QuitMaze);
	}

	public void PlayMaze() {
		if (colorblindMode.isOn) {
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		}
		else {
			trapMat.color = new Color32(255, 0, 0, 1);
			goalMat.color = new Color32(0, 255, 0, 1);
		}
		SceneManager.LoadScene("maze");
	}

	public void QuitMaze() {
		Debug.Log("Quit Game");
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
