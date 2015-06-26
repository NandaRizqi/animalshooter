using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public RectTransform healthTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	private int currentHealth;

	private int CurrentHealth
	{
		get{ return currentHealth; }
		set { 
			currentHealth = value; 
			HandleHealth();
		}
	}

	private int maxHealth;
	//public Text healthText;
	public Image visualHealth;
	private float coolDown;
	private bool onCD;
	public float tempo;

	// Use this for initialization
	void Start () {
		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = healthTransform.position.x - healthTransform.rect.width;
		currentHealth = maxHealth;
		onCD = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (Input.GetKey ("z")) {
//			if (currentHealth > 0)
//			{
//				currentHealth = currentHealth - 1f;
//				tempo = 0;
//			}
//		}
	}
	private void HandleHealth(){
		//healthText.text = "Health: " + currentHealth;

		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXValue, maxXValue);
		healthTransform.position = new Vector3 (currentXValue, cachedY);

		if (currentHealth > maxHealth / 2) //jika lebih dari 50%
		{
			visualHealth.color = new Color32 ((byte)MapValues (currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
				} 
		else //kurang dari 50%
		{
			visualHealth.color = new Color32 (255, (byte)MapValues(currentHealth,0 ,maxHealth / 2, 0, 255), 0, 255);
				}
		}
	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds (coolDown);
		onCD = false;
		}

	void OnTriggerStay(Collider other)
	{
		if (other.name == "Damage") 
		{
			if (onCD && currentHealth > 0)
			{
				StartCoroutine(CoolDownDmg());
				CurrentHealth -= 1;
			}
				}
		if (other.name == "Health") 
		{
			if (onCD && currentHealth < maxHealth)
			{
				StartCoroutine(CoolDownDmg());
				CurrentHealth += 1;
			}
				}
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return (x-inMin)*(outMax - outMin) / (inMax - inMin) + outMin;
	}
}
