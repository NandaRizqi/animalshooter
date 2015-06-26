using UnityEngine;
using System.Collections;

public class Vida : MonoBehaviour {
	GUISkin textButton;
	GUISkin textBox;
	float posX;
	float posY;
	float height;
	float isibar;
	float bar;
	int damage = 20;
	bool dead = false;
	GameObject WinCanvas;

//	public Enemy enemy;
	float CurrentHealth;
	float MaxHealth;

	public float tempo;

	// Use this for initialization
	void Start () {
		MaxHealth = 100;
		CurrentHealth = MaxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
		bar = 200;
		isibar = 200 * (CurrentHealth / MaxHealth);
		posX = 500;
		posY = 30;
		height = 20;

		if (dead) {
			Application.LoadLevel("Win");
		}
	}
	void OnGUI(){
		GUI.skin = textBox;
		GUI.Box(new Rect(posX, posY, bar, height),"HP :" + CurrentHealth.ToString("f0") + "/" + MaxHealth.ToString("f0"));
		GUI.skin = textButton;
		GUI.Button(new Rect(posX, posY, isibar, height)," ");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "weapon") {
			CurrentHealth = CurrentHealth - 20;
			tempo = -1;
			death();
		}

	}
	void death(){
		if (CurrentHealth == 0) {
			dead = true;		
		}
	}	
}
