using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public int speed = 6;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
	void fixUpdate(){
		Destroy (gameObject, 50.6f);
	}
}
