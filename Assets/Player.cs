using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float movementSpeed = 1.0f;
	public Rigidbody doorLight;
	public Rigidbody door;
	public Color readyColor = Color.green;
	public Color openColor = Color.black;
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
		
	}
	
	void OnTriggerEnter(Collider otherCollider) {
		
		if (otherCollider.gameObject.name.Contains("TeslaCoil")) {
			Debug.Log ("Tesla Coil has been hit!");
			doorLight.gameObject.renderer.material.SetColor ("_Color", readyColor);
			door.gameObject.renderer.material.SetColor ("_Color", openColor);
			successText.gameObject.renderer.enabled = true;
		}
	}
}
