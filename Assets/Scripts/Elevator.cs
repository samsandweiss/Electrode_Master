using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
	public Transform bottomBoundary;
	public Transform topBoundary;
	public float movementSpeed = 1.0f;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
	private bool atBottom;
	private bool atTop;
	public int state = 0;
	
	public bool isActivated;
	public bool movingDown;

	// Use this for initialization
	void Start ()
	{
		atBottom = false;
	}
	
	// Update is called once per frame
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
						
				}
			}
		
		} else {
			
			//moving up code
			if (atTop) {
			    isActivated = false;
			
			} else {
				if (isActivated) {
				movement = Vector3.up * movementSpeed * Time.deltaTime;
				gameObject.transform.Translate (movement);
						Debug.Log ("the code is supposed to move the elevator up");
				}
			}
		}
	}
	
	void OnTriggerEnter (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("ElevatorBottom")) {
			//state++;
			atBottom = true;
		}

			
		if (otherCollider.gameObject.name.Contains ("ElevatorTop")) {
			//state ++;
			atTop = true;
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
		isActivated = true; 
		
		if (movingDown) {
			movingDown = false;
		}
		else {
			movingDown = true;
		}
		
		}
	}


