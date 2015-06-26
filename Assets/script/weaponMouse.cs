using UnityEngine;
using System.Collections;

public class weaponMouse : MonoBehaviour {
	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatToHit;

	float timeTofire = 0;
	Transform firePoint;

	void Awake(){
		firePoint = transform.FindChild("Firepoint");
		if (firePoint == null) {
			Debug.LogError("No Firepoint? What?!");
		}
	}

	void Update () {

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				shoot ();
			}
		} 
		else {
			if(Input.GetButton("Fire1") && Time.time > timeTofire){
				timeTofire = Time.time + 1/fireRate;
				shoot();
			}
		}
	}

	void shoot(){
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointposition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointposition, mousePosition - firePointposition, 100, whatToHit);
		Debug.DrawLine (firePointposition, (mousePosition-firePointposition)*100, Color.cyan);
		if (hit.collider != null) {
			Debug.Log("Test");
			Debug.DrawLine(firePointposition, hit.point, Color.red);
			Debug.Log("We hit" + hit.collider.name + "and did" + damage + "damage.");
		}
	}
}
