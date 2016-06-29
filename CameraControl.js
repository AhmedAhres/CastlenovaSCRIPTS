#pragma strict

var target : Transform;
var distance = - 10;
var lift = 1.5;


function Update () 
{
	transform.position = target.position + Vector3(distance,lift,0);
	transform.LookAt (target);

}