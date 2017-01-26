#pragma strict

internal var animator : Animator; //stores the animator component
var v : float; //vertical movement
var h : float; //horizontal movement
var sprint : float;
var attack : float;
var death : float;
var hit : float;
var idle : float;
var death_a : float;


function Start () {

	animator = GetComponent(Animator); //assigns Animator component when we start the game
	
}

function Update () {

	
	v = Input.GetAxis("Vertical");
	h = Input.GetAxisRaw("Horizontal");

	
		if(Input.GetButton("Fire6")) {
		idle = 0.2;
	}
	else {
	
		idle = 0.0;
		
	}
	
		if(Input.GetButton("Fire5")) {
		death_a = 0.2;
	}
	else {
	
		death_a = 0.0;
		
	}
	
}

function FixedUpdate () {

	//set the "Walk" parameter to the v axis value
	animator.SetFloat ("Walk", v);

	animator.SetFloat ("Turn", h);
	animator.SetFloat ("Sprint", sprint);
	animator.SetFloat ("Attack", attack);
	animator.SetFloat ("Death", death);
	animator.SetFloat ("Hit", hit);
	animator.SetFloat ("Idle", idle);
	animator.SetFloat ("death_a", death_a);
	
}

