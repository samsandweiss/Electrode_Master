using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
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
	public TextMesh successText;
	
	public float minChargeValue = 0.00f;
	public float maxChargeValue = 20.0f;
	public float drainSpeed = 1.000f;
	public float chargeValue = 1.000f;
	public float chargeSpeed = 5.000f;
	private Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start ()
	{
		successText.gameObject.renderer.enabled = false;
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		
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
			otherCollider.gameObject.GetComponent<TeslaCoil> ().ShowMessage ();
			hasEnergy = true;
			gameObject.renderer.material.color = holdingEnergy;
		}
		
//		if (otherCollider.gameObject.name.Contains ("Door")) {
//			if (hasEnergy) {
//				otherCollider.gameObject.GetComponent<Door> ().ShowUnlockedMessage ();
//				atTheDoor = true;
//			} else {
//				otherCollider.gameObject.GetComponent<Door> ().ShowLockedMessage ();
//			}
//		}
		
	}
	
	void OnTriggerStay (Collider otherCollider) {
		
		if (otherCollider.gameObject.name.Contains ("TeslaCoil")) {
			charge ();
		}
		
		if (otherCollider.gameObject.name.Contains ("Switch")) {
			if (Input.GetKey (KeyCode.Return)) {
				if (otherCollider.gameObject.GetComponent<Switch>().activated == false) {
					otherCollider.gameObject.GetComponent<Switch>().Activate();
					drainCharge();
					Debug.Log (chargeValue);
				}
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
			otherCollider.gameObject.GetComponent<TeslaCoil> ().HideMessage ();
			atTheDoor = false;
		}
	}

	void charge ()
	{
		if (chargeValue < maxChargeValue) {
			chargeValue += Time.deltaTime * chargeSpeed;
			Debug.Log (chargeValue);
			Debug.Log (Time.deltaTime);
		}
	}
	
	void drainCharge() {
		if (chargeValue > minChargeValue) {
			chargeValue -= Time.deltaTime * drainSpeed;
			Debug.Log (chargeValue);
			Debug.Log (Time.deltaTime);
		}
	}
}
