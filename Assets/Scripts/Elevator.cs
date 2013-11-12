using UnityEngine;
using System.Collections;


public class Elevator : MonoBehaviour {
	public Transform bottomBoundary;
	public Transform topBoundary;
	
	public float movementSpeed = 1.0f;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
	private bool atBottom;
	private bool atTop;
	public int state;

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

		if (state == 1) {
			//move elevator down
		}
		if (state == 3) {
			//move elevator up
		}
		
	}
	
	void onTriggerStay () {
		//if elevator hits bottom
		//then state ++ and set bool elevator bottom to true
		
		//if elevator hits top
		//then state ++ elevator movement and se
		
		
	
	}
	
	void activate() {
		state ++;
		if (state > 3) {
			state = 0;
		}
	}
}
