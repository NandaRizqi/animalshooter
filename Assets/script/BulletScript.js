#pragma strict
public var speed: int = 6;

function Start () {
	rigidbody2D.velocity.x = speed;
}
function OnBecameInvisible () {
	Destroy(gameObject);
}
