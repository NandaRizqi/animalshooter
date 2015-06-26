using UnityEngine;
using System.Collections;

public class Score1 : MonoBehaviour {
		static int Score = 0;
		static int highScore = 0;
		
		static public void AddPoint(){
			Score+=10;
			
			if (Score > highScore) {
				highScore = Score;
			}
		}

	void Start(){
			highScore = PlayerPrefs.GetInt ("highScore", 0);
			Score = 0;
		}
		
		void OnDestroy(){
			PlayerPrefs.SetInt ("Score", Score);
			PlayerPrefs.SetInt ("highScore", highScore);
		}
		
	// Update is called once per frame
		void Update () {
			guiText.text = "Score :" + Score+ "\nHigh Score :" + highScore;
		}
}

