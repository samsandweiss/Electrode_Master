using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool hasEnergy = false;
	public bool atTheDoor = false;
	public float movementSpeed = 1.0f;
	public Rigidbody door;
	public Light doorLight;
	public Color holdingEnergy = Color.yellow;
	public TextMesh successText;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
	
	private float chargeValue = 1.000f;
	private float chargeSpeed = 5.000f;
	
	// Use this for initialization
	void Start () {
		successText.gameObject.renderer.enabled = false;
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Debug.Log(gameObject.transform.rotation.);
		
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			//moves the player to the left with smooth movement
			
			rigidbody.AddForce(Vector3.left*20);
			
			
		//	movement = Vector3.left * movementSpeed * Time.deltaTime;
		//	gameObject.transform.Translate (movement);
		}
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			//moves the player to the left with smooth movement
			
			rigidbody.AddForce(Vector3.right*20);
			
		//	movement = Vector3.right * movementSpeed * Time.deltaTime;
		//	gameObject.transform.Translate (movement);

		}
		
		if (Input.GetAxisRaw ("Vertical") < 0) {
			//moves the player to the left with smooth movement
			movement = Vector3.back * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}
		
		if (Input.GetAxisRaw ("Vertical") > 0) {
			//moves the player to the left with smooth movement
			movement = Vector3.forward * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}
		
		if ((Input.GetKeyDown (KeyCode.F) && atTheDoor)) {
			door.GetComponent<Door>().Open();
			Debug.Log("Door should have opened");
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			rigidbody.AddForce(Vector3.up*100);
		}
		
	}
	
	void OnTriggerEnter(Collider otherCollider) {
		
		if (otherCollider.gameObject.name.Contains("TeslaCoil")) {
			otherCollider.gameObject.GetComponent<TeslaCoil>().ShowMessage();
			hasEnergy = true;
			gameObject.renderer.material.color = holdingEnergy;
		}
		
		if (otherCollider.gameObject.name.Contains("Door")) {
			if (hasEnergy) {
				otherCollider.gameObject.GetComponent<Door>().ShowUnlockedMessage();
				atTheDoor = true;
			} else {
				otherCollider.gameObject.GetComponent<Door>().ShowLockedMessage();
			}
		}
	}
	
	void OnTriggerStay(Collider otherCollider) {
		if (otherCollider.gameObject.name.Contains("TeslaCoil")) {
		charge();
		}
	}
		
	
	void OnTriggerExit(Collider otherCollider) {
		if (otherCollider.gameObject.name.Contains("Door")) {
			otherCollider.gameObject.GetComponent<Door>().HideMessage();
			atTheDoor = false;
		}
		
		if (otherCollider.gameObject.name.Contains("TeslaCoil")) {
			otherCollider.gameObject.GetComponent<TeslaCoil>().HideMessage();
			atTheDoor = false;
		}
	}
	void charge () {
		chargeValue += Time.deltaTime*chargeSpeed;
		Debug.Log(chargeValue);
		Debug.Log(Time.deltaTime);
}
}
