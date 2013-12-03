﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	GameObject switchTrapDoor;
	public ParticleSystem particleSystem;
	GameObject ParticleSystem;
	
	//bools for triggering doors and energy
	public bool hasEnergy = false;
	public bool atTheDoor = false;
	
	//values for character jump and move speed 
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	
	public Rigidbody door;
	public Light doorLight;
	public Color holdingEnergy = Color.yellow;
	public Material noEnergy;
	public Material Energy;
	
	public SwitchElevator currentSwitch;
	public float minChargeValue = 0.00f;
	public float maxChargeValue = 20.00000000f;
	public float drainSpeed = 1.000f;
	public float chargeValue = 1.000f;
	public float chargeSpeed = 5.000f;
	private Vector3 moveDirection = Vector3.zero;


	private float trapDoorCV = 5.0f;
	private float elevatorCV = 5.0f;
	private float doorCV = 5.0f;

	// Use this for initialization
	void Start ()
	{
		switchTrapDoor = GameObject.Find ("SwitchTrapDoor");
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(chargeValue);

		//character controller movement.
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed; 
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);


		if (Input.GetButtonDown ("Fire2")) {
			Application.LoadLevel (0);
		}

		// logic for particle system for charge
		if (chargeValue > minChargeValue) {
			particleSystem.enableEmission = true;
			gameObject.renderer.material = Energy;
		} else {
			particleSystem.enableEmission = false;
			gameObject.renderer.material = noEnergy;

		}

		//logic to activate the current switch that the player is interacting with.
		if ((currentSwitch != null) && (Input.GetButtonDown ("Fire1"))) {
			currentSwitch.Activate ();
		}

		//logic to active doors
		if ((Input.GetKeyDown (KeyCode.F) && atTheDoor)) {
			door.GetComponent<Door> ().Open ();
			Debug.Log ("Door should have opened");
		}	
	}
	
	void OnTriggerEnter (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			hasEnergy = true;
			//gameObject.renderer.material.color = holdingEnergy;
		}
		
		if (otherCollider.gameObject.name.Contains ("Platform")) {
			gameObject.transform.parent = otherCollider.gameObject.transform;
		}
		
		if (otherCollider.gameObject.tag.Equals ("Finish")) {
			Application.LoadLevel (1);
			Debug.Log ("should have loaded the next level");
		}

		if (otherCollider.gameObject.tag.Equals ("Reload")) {
			Application.LoadLevel (0);
		}
		
		if (otherCollider.gameObject.name.Equals ("SwitchElevator")) {
			currentSwitch = otherCollider.gameObject.GetComponent<SwitchElevator> ();
		}
		
		//Debug.Log("getkeyreturn "+Input.GetKey(KeyCode.Return));
		//Debug.Log("touch" + otherCollider.name);
	}
	
	void OnTriggerStay (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			charge ();
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchTrapDoor") && chargeValue > trapDoorCV) {
			if (Input.GetButtonDown ("Fire1")) {
				//activate trap door
				switchTrapDoor.gameObject.GetComponent<sTrapDoor> ().Activate ();
				drainCharge ();
				//Debug.Log (chargeValue);
			}
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchDoor")) {
			if (Input.GetButtonDown ("Fire1")) {
				otherCollider.gameObject.GetComponent<SwitchDoor> ().Activate ();
				drainCharge ();
				//Debug.Log (chargeValue);
			}
		}
	}
	
	void OnTriggerExit (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			atTheDoor = false;
		}
		
		if (otherCollider.gameObject.name.Contains ("Platform")) {
			gameObject.transform.parent = null;
			Debug.Log ("Unparented");
		}
		
		if (otherCollider.gameObject.name.Equals ("SwitchElevator")) {
			currentSwitch = null;
		}
	}

	void charge ()
	{
		if (chargeValue < maxChargeValue) {
			chargeValue += Time.deltaTime * chargeSpeed;
			//Debug.Log (chargeValue);
			//Debug.Log (Time.deltaTime);
		}
	}
	
	void drainCharge ()
	{
		if (chargeValue > minChargeValue) {
			chargeValue -= 5f;
			//Debug.Log (chargeValue);
			//Debug.Log (Time.deltaTime);
		}
		if (chargeValue < 5 ) {
			chargeValue = 0;
		}

		
	}
}
