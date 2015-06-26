using UnityEngine;
using System.Collections;

public class Showscore : MonoBehaviour {


	static int Score;
	static int highScore;

	static public void addPoint(){
		if (Score > highScore) {
			highScore = Score;
		}
	}


	void Start (){
		Score1.AddPoint();
		Score = PlayerPrefs.GetInt ("Score", Score);
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}
//	void onDestroy(){
//		PlayerPrefs.SetInt ("Score", Score);
//		PlayerPrefs.SetInt ("highScore", highScore);
//	}

	void Update () {
		//Score = PlayerPrefs.GetInt ("Score",Score);
		guiText.text = "Score Kamu: " + Score + "\nHigh Score: " + highScore;
	}
}
