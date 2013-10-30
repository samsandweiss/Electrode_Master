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
	
	// Use this for initialization
	void Start () {
		successText.gameObject.renderer.enabled = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log(gameObject.transform.rotation.);
		
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			//moves the player to the left with smooth movement
			movement = Vector3.left * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			//moves the player to the left with smooth movement
			movement = Vector3.right * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);

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
		
		if ((Input.GetKeyDown (KeyCode.Space) && atTheDoor)) {
			door.GetComponent<Door>().Open();
			Debug.Log("Door should have opened");
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
	
}
