using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
	public Transform bottomBoundary;
	public Transform topBoundary;
	public float movementSpeed = 1.0f;
	public float reverseMovementSpeed = -1.0f;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
	
	private bool atBottom;
	private bool atTop;

	
	public bool isActivated;
	public bool movingDown;
	public int counter; 
	public int modCounter;
	public int elevatorRequiredCharge = 20;

	private bool flag = true; 
	private bool secondflag = true;
	public AudioClip mechsound;
	public AudioClip stopsound;

	// Use this for initialization
	void Start ()
	{
		secondflag = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (modCounter == 0) {
			//elevator at top or stopped
			flag = true;
			if (secondflag) {
				secondflag = false;
				audio.clip = stopsound;
				audio.Play();
			}
		
		}
		
		if (modCounter == 1) {
			//elevator moving down
			movement = Vector3.down * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
				secondflag = true;
			if (flag) {
				flag = false;
				audio.clip = mechsound;
				audio.Play();
			}
		}
		
		if (modCounter == 2) {
			//elevator at bottom or stopped (preparing to move up
				flag = true;
				if (secondflag) {
					secondflag = false;
					audio.clip = stopsound;
					audio.Play();
				}
		}
		
		if (modCounter == 3) {
			//elevator moving up
			movement = Vector3.up * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
					secondflag = true;
			if (flag) {
				flag = false;
				audio.clip = mechsound;
				audio.Play();
			}
		}
	}
		
	
	void OnTriggerEnter (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("ElevatorBottom")) {
		counter = 2;
		modCounter = 2;
		}

			
		if (otherCollider.gameObject.name.Contains ("ElevatorTop")) {
			counter = 0;
			modCounter = 0;
		
	
		
	}
	}
	
//	void onTriggerExit (Collider otherCollider)
//	{
//			if (otherCollider.gameObject.name.Contains ("ElevatorBottom")) {
//			//state++;
//			atBottom = false;
//		}
//
//			
//		if (otherCollider.gameObject.name.Contains ("ElevatorTop")) {
//			//state ++;
//			atTop = false;
//		}
//		
//	
//	}
	
	public void Activate ()
	{
		counter++;
		modCounter = (counter % 4);
		
//		Ye old code
//		isActivated = true; 
//		
//		if (movingDown) {
//			movingDown = false;
//		Debug.Log("Moving Down has been set to false");
//		}
//		 else {
//			movingDown = true;
//			Debug.Log("moving down is true");
//		
//	}
	} 
	
}


