using UnityEngine;
using System.Collections;

public class lihatscore : MonoBehaviour {

	static int Score;
	static int highscore;
	
	static public void AddPoint(){
		Score += 100;
		if (Score > highscore) {
			highscore=Score;
		}
	}
	void Start () {
		Score = PlayerPrefs.GetInt ("Score " + Score);
		highscore = PlayerPrefs.GetInt ("High " + 0);
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "    Score : " + Score + "\n High : " + highscore;
	}
}
