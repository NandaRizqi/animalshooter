using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public Rigidbody2D bullet;
	float attackRate  = .5f;
	float coolDown;
	bool lookright = true;

//	float takenDamage = 0.2f;
	public float speed = 6.0f;
	public float maxpos=-3.20f;
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
		position.x = Mathf.Clamp (position.x,-6.95f,-3.20f);
		transform.position = position;

		if (Time.time >= coolDown) {
			if(Input.GetKeyDown(KeyCode.F)){
				bulletAttack();
			}
		}
	}

	void bulletAttack(){
		if (lookright) {
			Rigidbody2D bprefab = Instantiate (bullet, transform.position, Quaternion.identity)as Rigidbody2D;
			bprefab.rigidbody2D.AddForce (Vector3.right * 1500);
			coolDown = Time.time + attackRate;
		}else{
			Rigidbody2D bprefab = Instantiate (bullet, transform.position, Quaternion.identity)as Rigidbody2D;
			bprefab.rigidbody2D.AddForce (-Vector3.right * 1000);
			coolDown = Time.time + attackRate;
		}

	}

	void Movement()
	{
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if (Input.GetAxisRaw ("Horizontal") >= .01f)
		{
			lookright = true;
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);

				}
		if (Input.GetAxisRaw ("Horizontal") <= -.01f)
		{
			lookright = false;
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
