using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
	static int Score = 0;
	static int highScore = 0;

	static public void addPoint(){
		Score+=100;

		if (Score > highScore) {
			highScore = Score;
		}
	}

	void Start(){
		Score = PlayerPrefs.GetInt ("Score", 0);
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}

	void onDestroy(){
		PlayerPrefs.SetInt ("Score", Score);
		PlayerPrefs.SetInt ("highScore", highScore);
	}

	void Update () {
		guiText.text = "Score: " + Score + "\nHigh Score: " + highScore;
	}
}
