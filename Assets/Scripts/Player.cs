using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject switchTrapDoor;
	
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
	
	public float minChargeValue = 0.00f;
	public float maxChargeValue = 20.0f;
	public float drainSpeed = 1.000f;
	public float chargeValue = 1.000f;
	public float chargeSpeed = 5.000f;
	private Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {

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
			gameObject.renderer.material.color = holdingEnergy;
		}
		
		if (otherCollider.gameObject.name.Contains ("Platform")) {
			gameObject.transform.parent = otherCollider.gameObject.transform;
		}
		
		if (otherCollider.gameObject.tag.Equals ("Finish")) {
			Application.LoadLevel(1);
		}
		
	}
	
	void OnTriggerStay (Collider otherCollider) {
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			charge ();
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchTrapDoor")) {
			//if (Input.GetKey (KeyCode.Return)) {
				if (otherCollider.gameObject.GetComponent<Switch>().activated != true) {
					otherCollider.gameObject.GetComponent<Switch>().Activate();
					drainCharge();
					//Debug.Log (chargeValue);
				}
			//}
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchDoor")) {
			if (Input.GetKey (KeyCode.Return)) {
				otherCollider.gameObject.GetComponent<SwitchDoor>().Activate();
				drainCharge();
				//Debug.Log (chargeValue);
			}
		}
		
		if (otherCollider.gameObject.name.Contains ("SwitchTrapDoor")) {
			if (Input.GetKey (KeyCode.Return)) {
				otherCollider.gameObject.GetComponent<Switch>().Activate();
				drainCharge();
				//Debug.Log (chargeValue);
			}
		}
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
	}

	void charge ()
	{
		if (chargeValue < maxChargeValue) {
			chargeValue += Time.deltaTime * chargeSpeed;
			//Debug.Log (chargeValue);
			//Debug.Log (Time.deltaTime);
		}
	}
	
	void drainCharge() {
		if (chargeValue > minChargeValue) {
			chargeValue -= Time.deltaTime * drainSpeed;
			//Debug.Log (chargeValue);
			//Debug.Log (Time.deltaTime);
		}
		
	}
	
}
