using UnityEngine;
using System.Collections;

public class winscene : MonoBehaviour {
	public string levelSelect;
	public string mainMenu;
	public bool isPaused;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void newgame()
	{
		Application.LoadLevel (levelSelect);
	}
	public void Quit()
	{
		Application.LoadLevel (mainMenu);
	}
}
