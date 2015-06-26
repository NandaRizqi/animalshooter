using UnityEngine;
using System.Collections;

public class scorePoint : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "weapon") {

			Score1.AddPoint();
			Destroy(collider.gameObject);
		//gameObject.SetActive(false);
		}
	}
}
