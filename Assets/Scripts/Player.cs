using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	GameObject switchTrapDoor;
	public ParticleSystem particleSystem;
	
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
	public bool atMinimum;
	public SwitchElevator currentSwitch;
	public float minChargeValue = 0.00f;
	public float maxChargeValue = 20.00000000f;
	public float drainSpeed = 1.000f;
	public float chargeValue = 1.000f;
	public float chargeSpeed = 5.000f;
	private Vector3 moveDirection = Vector3.zero;
	private int tempCharge = 20;


	

	ParticleSystem playerPS;
	
	// Use this for initialization
	void Start ()
	{
		switchTrapDoor = GameObject.Find ("SwitchTrapDoor");

	}
	
	
	// Update is called once per frame
	void Update ()
	{

		if (chargeValue > minChargeValue) {
			particleSystem.enableEmission = true;
			particleSystem.emissionRate = 2;
			gameObject.renderer.material = Energy;
			atMinimum = false;
			if (chargeValue > 20) {
				particleSystem.emissionRate = 7;
			}
		} else {
			particleSystem.enableEmission = false;
			gameObject.renderer.material = noEnergy;
			atMinimum = true;

		}


		 

	

			if ((currentSwitch != null) && (Input.GetKeyDown (KeyCode.Return))) {
				currentSwitch.Activate ();
				drainCharge(tempCharge);
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
		
		if (otherCollider.gameObject.name.Contains ("SwitchTrapDoor")) {
			int tempTrapDoorChrg = otherCollider.gameObject.GetComponent<sTrapDoor> ().trapDoorChrg;
			if (tempTrapDoorChrg < chargeValue) {
			
				if (Input.GetKeyUp (KeyCode.Return)) {
					//activate trap door
					switchTrapDoor.gameObject.GetComponent<sTrapDoor> ().Activate ();
					drainCharge (tempTrapDoorChrg);
					//Debug.Log (chargeValue);
				}
			}
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchDoor")) {
			if (Input.GetKeyUp (KeyCode.Return)) {
				otherCollider.gameObject.GetComponent<SwitchDoor> ().Activate ();
				 drainCharge(tempCharge);
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
	
	void drainCharge (int activeChrg)
	{
		if (chargeValue > minChargeValue) {
			chargeValue -= activeChrg;
		} else {
			atMinimum = true;
			chargeValue = 0;
				    
		}
	}
	//Debug.Log (chargeValue);
	//Debug.Log (Time.deltaTime);
}
		

