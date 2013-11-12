using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public Transform bottomBoundary;
	public Transform topBoundary;
	
	public float movementSpeed = 1.0f;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
	private bool atBottom;
	private bool atTop;

	// Use this for initialization
	void Start () {
		atBottom = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void Activate() {
		if (atBottom == false) {
			movement = Vector3.down * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}
		
		if (atBottom == true) {
			movement = Vector3.up * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}		
	}
	
	void OnTriggerEnter (Collider otherCollider) {
		
		if (otherCollider.gameObject.name.Contains ("ElevatorBottom")) {
			atBottom = true;
		}
			
		if (otherCollider.gameObject.name.Contains ("ElevatorTop")) {
			atTop = true;
		}
	}
}
