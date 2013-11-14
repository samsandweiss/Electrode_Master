using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
	public Transform bottomBoundary;
	public Transform topBoundary;
	public float movementSpeed = 1.0f;
	public float reverseMovementSpeed = -1.0f;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
<<<<<<< HEAD
	private bool atBottom;
	private bool atTop;
	public int state = 0;
	public int counter = 0;
	
	public bool isActivated;
=======
>>>>>>> ecfc662aecf11d73b739b5c83c8814ef243e12ea
	public bool movingDown;
	public int counter; 
	public int modCounter;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
<<<<<<< HEAD
	void Update ()
	{
		if (movingDown) {
			//moving down code
			if (atBottom) {
				isActivated = false;
				
			} else {
				if (isActivated) {
				movement = Vector3.down * movementSpeed * Time.deltaTime;
				gameObject.transform.Translate (movement);
				movingDown = false;
						
				}
			}
		
		} else {
			Debug.Log("movingDown = false");
			//moving up code
			if (atTop) {
			    isActivated = false;
=======
	void Update () {
		
		if (modCounter == 0) {
			//elevator at top or stopped
		
		}
		
		if (modCounter == 1) {
			//elevator moving down
			movement = Vector3.down * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}
		
		if (modCounter == 2) {
			//elevator at bottom or stopped (preparing to move up)
>>>>>>> ecfc662aecf11d73b739b5c83c8814ef243e12ea
			
		}
		
		if (modCounter == 3) {
			//elevator moving up
			movement = Vector3.up * movementSpeed * Time.deltaTime;
			gameObject.transform.Translate (movement);
		}
	}
		
	
		//all ye old code
//	{
//		if (movingDown) {
//			//moving down code
//			if (atBottom) {
//				isActivated = false;
//			
//				
//			} else {
//				if (isActivated) {
//					movement = Vector3.down * movementSpeed * Time.deltaTime;
//					gameObject.transform.Translate (movement);
//						
//				}
//			}
//		
//		} else {
//			
//			//moving up code
//			if (atTop) {
//				isActivated = false;
//			   
//			} else {
//				if (isActivated) {
//					Debug.Log("Reverse Speed activated");
//					movement = Vector3.up * movementSpeed * Time.deltaTime;
//					gameObject.transform.Translate (movement);
//					Debug.Log ("the code is supposed to move the elevator up");
//				}
//			}
//		}
//	}
	
	void OnTriggerEnter (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("ElevatorBottom")) {
		counter = 2;
		modCounter = 2;
		}

			
		if (otherCollider.gameObject.name.Contains ("ElevatorTop")) {
<<<<<<< HEAD
			//state ++;
			atTop = true;
			
=======
			counter = 0;
			modCounter = 0;
			
	
>>>>>>> ecfc662aecf11d73b739b5c83c8814ef243e12ea
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
<<<<<<< HEAD
		counter+1
		counter % 3;
		isActivated = true; 
		
		if (movingDown) {
			movingDown = false;
		}
		else {
			movingDown = true;
		}
=======
		counter++;
		modCounter = (counter % 4);
			Debug.Log(modCounter);

>>>>>>> ecfc662aecf11d73b739b5c83c8814ef243e12ea
		
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


