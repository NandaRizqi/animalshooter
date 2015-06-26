using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string resume;

	// Use this for initialization
	public void newgame(){
		Application.LoadLevel (startLevel);
	}
	public void Quit(){
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
	public void volumeControl(float volumeControl)
	{
		audio.volume = volumeControl;
	}
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}
