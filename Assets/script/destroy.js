﻿#pragma strict

function OnCollisionEnter2D(col :Collision2D){
	if(col.gameObject.tag == "weapon"){
	Destroy(col.gameObject);
	}
}