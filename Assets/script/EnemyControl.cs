using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	public Rigidbody2D bullet;
	float attackRate  = .5f;
	float coolDown;
	bool lookleft = true;
	
//	float takenDamage = 0.2f;
	public float speed = 6.0f;
	public float maxpos= 8.70f;
	Animator anim;
	Vector3 position;
	void Start()
	{
		//movement
		anim = GetComponent<Animator>();
		position = transform.position;
	}
	
	void Update ()
	{
		Movement ();
		
		position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.position = position;
		position.x = Mathf.Clamp (position.x,3.4f,8.70f);
		transform.position = position;
		
		if (Time.time >= coolDown) {
			if(Input.GetKeyDown(KeyCode.H)){
				bulletAttack();
			}
		}
	}
	
	void bulletAttack(){
		if (lookleft) {
			Rigidbody2D bprefab = Instantiate (bullet, transform.position, Quaternion.identity)as Rigidbody2D;
			bprefab.rigidbody2D.AddForce (-Vector3.right * 1500);
			coolDown = Time.time + attackRate;
		}else{
			Rigidbody2D bprefab = Instantiate (bullet, transform.position, Quaternion.identity)as Rigidbody2D;
			bprefab.rigidbody2D.AddForce (Vector3.right * 1000);
			coolDown = Time.time + attackRate;
		}
		
	}
	
	void Movement()
	{
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		
		if (Input.GetAxisRaw ("Horizontal") <= -.01f)
		{
			lookleft = true;
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
			
		}
		if (Input.GetAxisRaw ("Horizontal") >= .01f)
		{
			lookleft = false;
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
			
		}
		
	}
	
//	public IEnumerator TakenDamage(){
//		renderer.enabled = false;
//		yield return new WaitForSeconds (takenDamage);
//		renderer.enabled = true;
//		yield return new WaitForSeconds (takenDamage);
//		renderer.enabled = false;
//		yield return new WaitForSeconds (takenDamage);
//		renderer.enabled = true;
//		yield return new WaitForSeconds (takenDamage);
//		renderer.enabled = false;
//		yield return new WaitForSeconds (takenDamage);
//		renderer.enabled = true;
//		yield return new WaitForSeconds (takenDamage);
//	}

}
