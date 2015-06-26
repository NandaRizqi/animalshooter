using UnityEngine;
using System.Collections;

public class DestroyC : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "weapon"){
			Destroy(col.gameObject);
		}
	}
}
