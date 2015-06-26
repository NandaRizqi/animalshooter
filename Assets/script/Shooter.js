#pragma strict
public var bullet : GameObject;

function Update () {
	rigidbody2D.velocity.y = Input.GetAxis("Horizontal") * 15;
	
	if(Input.GetKeyDown("space")){
	Instantiate(bullet, transform.position,Quaternion.identity);
	}
}