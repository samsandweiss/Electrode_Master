using UnityEngine;
using System.Collections;
public class TrapDoor : MonoBehaviour
{
	public Transform rotationCenter;
	public int rotationSpeed = 50;
	public bool upPosition;
	public bool downPosition;
	public bool movingForward;
	public bool isLocked;
	public int counter;
	public int modCounter;
	
	// Use this for initialization
	void Start ()
	{
		isLocked = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (modCounter == 0) {
			//trap door at bottom or stopped
		}
		
		
		if (modCounter == 1) {
			//trap door moving up
			rotationCenter.Rotate (Vector3.down, rotationSpeed * Time.deltaTime);
		}
		
		if (modCounter == 2) {
			//trap door at top or stopped (preparing to move up)
			
		}
		
		if (modCounter == 3) {
			//trap door moving down
			rotationCenter.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
		}
		
	}
	
	void OnTriggerEnter (Collider otherCollider)
	{
		
		if (otherCollider.gameObject.name.Contains ("TrapDoorBottom")) {
			counter = 0;
			modCounter = 0;
		}
		
		if (otherCollider.gameObject.name.Contains ("TrapDoorTop")) {
			counter = 2;
			modCounter = 2;
		}
		
	}
	
	public void Activate ()
	{
		if (!isLocked) {
			counter++;
			modCounter = (counter % 4);
			Debug.Log (modCounter);
		}
	}
	public void Lock ()
	{
		isLocked = true;
	}
}
