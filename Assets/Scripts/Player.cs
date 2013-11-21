using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject switchTrapDoor;
	
	//bools for triggering doors and energy
	public bool hasEnergy = false;
	public bool atTheDoor = false;
	
	//values for character jump and move speed 
	public float speed = 1.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	
	public Rigidbody door;
	public Light doorLight;
	public Color holdingEnergy = Color.yellow;
	public Color noEnergy = Color.blue;
	
	public SwitchElevator currentSwitch;
	public bool atMinimum;
	public float minChargeValue = 0.00f;
	public float maxChargeValue = 20.0f;
	public float drainSpeed = 1.000f;
	public float chargeValue = 0.000f;
	public float chargeSpeed = 5.000f;
	private Vector3 moveDirection = Vector3.zero;

	public int elevatorChrg = 20;


	public TrapDoor trapDoor;

	public ParticleSystem chargeParticles;
	

	// Use this for initialization
	void Start () {
		switchTrapDoor = GameObject.Find("SwitchTrapDoor");
		gameObject.renderer.material.color = noEnergy;
	}

	
	
	// Update is called once per frame
	void Update () {

		if(chargeValue > 1) {
			hasEnergy = true;
			Debug.Log (chargeValue);
		}
		if(hasEnergy) {
			gameObject.renderer.material.color = holdingEnergy;
			chargeParticles.transform.renderer.enabled = true;
		} else  {
			gameObject.renderer.material.color = noEnergy;
			chargeParticles.transform.renderer.enabled = false;
		}



		
		if ((currentSwitch != null) && (Input.GetKeyDown (KeyCode.Return))) {
			currentSwitch.Activate();

		}
		
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
 
		
		if ((Input.GetKeyDown (KeyCode.F) && atTheDoor)) {
			door.GetComponent<Door> ().Open ();
			Debug.Log ("Door should have opened");
		}	
	}
	
	void OnTriggerEnter (Collider otherCollider)
	{
	
		
		if (otherCollider.gameObject.name.Contains ("Platform")) {
			gameObject.transform.parent = otherCollider.gameObject.transform;
		}
		
		if (otherCollider.gameObject.tag.Equals ("Finish")) {
			Application.LoadLevel(1);
		}

		if (otherCollider.gameObject.tag.Equals ("Reload")) {
			Application.LoadLevel(0);
		}
		
		if (otherCollider.gameObject.name.Equals ("SwitchElevator")) {
			 currentSwitch = otherCollider.gameObject.GetComponent<SwitchElevator>();
		}
		
		//Debug.Log("getkeyreturn "+Input.GetKey(KeyCode.Return));
		//Debug.Log("touch" + otherCollider.name);
	}
	
	void OnTriggerStay (Collider otherCollider) {
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			charge ();
			Debug.Log("Charge should be working");
			Debug.Log(chargeValue);
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchTrapDoor")) {
			if(!atMinimum) {
			if (Input.GetKeyUp (KeyCode.Return)) {
				//activate trap door
				switchTrapDoor.gameObject.GetComponent<sTrapDoor>().Activate();
				drainCharge();
				//Debug.Log (chargeValue);
				}
			}
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchDoor")) {
			if (Input.GetKeyUp (KeyCode.Return)) {
				otherCollider.gameObject.GetComponent<SwitchDoor>().Activate();
				drainCharge();
				//Debug.Log (chargeValue);
			}
		}


//		if (otherCollider.gameObject.name.Contains ("SwitchElevator")) {
//			if (Input.GetKey (KeyCode.Return)) {
//				
//				otherCollider.gameObject.GetComponent<SwitchElevator>().Activate();
//				drainCharge();
//				//Debug.Log (chargeValue);
//			}
//		}
	}
	
	void OnTriggerExit (Collider otherCollider)
	{
//		if (otherCollider.gameObject.name.Contains ("Door")) {
//			otherCollider.gameObject.GetComponent<Door> ().HideMessage ();
//			atTheDoor = false;
//		}
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			atTheDoor = false;
		}
		
		if (otherCollider.gameObject.name.Contains ("Platform")) {
			gameObject.transform.parent = null;
			Debug.Log("Unparented");
		}
		
		if (otherCollider.gameObject.name.Equals ("SwitchElevator")) {
			currentSwitch = null;
		}
	}

	void charge ()
	{
		if (chargeValue < maxChargeValue) {
			chargeValue += Time.deltaTime * chargeSpeed;
			Debug.Log (chargeValue);
			//Debug.Log (Time.deltaTime);
		}
	}
	
	void drainCharge() {
		 if (chargeValue > minChargeValue) {
			chargeValue -= elevatorChrg;
			//Debug.Log (Time.deltaTime);
		}
//		  else {
//			hasEnergy = false;
//			atMinimum = true;
//			chargeValue = 0;
//		
//	}
}
}
