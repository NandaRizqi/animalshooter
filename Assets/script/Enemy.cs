using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
//	public Vida GUIhp;

	//enemy starting-end
	double startingPos;
	double endPos;
	//enemy move right
	public int unitsToMove = 5;
	//enemy movement speed
	public int moveSpeed = 2;
	//enemy move right or left
	bool moveRight = true;
	public float maxpos=3.10f;

	void Awake(){
		startingPos = transform.position.x;
		endPos = startingPos + unitsToMove;
	}

	void Update(){
		if (moveRight) {
			rigidbody2D.position += Vector2.right * moveSpeed * Time.deltaTime;
		}
		if (rigidbody2D.position.x >= endPos) {
			moveRight = false;
		}
		if (!moveRight) {
			rigidbody2D.position -= Vector2.right * moveSpeed * Time.deltaTime;
		}
		if(rigidbody2D.position.x <= startingPos){
			moveRight = true;
		}
	}

	int damageValue = 1;

//	void OnTriggerEnter(Collider coll){
//		if (coll.gameObject.tag == "Player") {
//			GUIhp.SendMessage("Playerdamage", damageValue, SendMessageOptions.DontRequireReceiver);
//			GUIhp.enemy.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
//		}
//	}
}
