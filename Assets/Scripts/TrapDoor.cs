using UnityEngine;
using System.Collections;
public class TrapDoor : MonoBehaviour
{
	public Transform rotationCenter;
	public int rotationSpeed = 50;
	public bool isLocked;
	public int counter;
	public int modCounter;
	private bool flag = true;
	private bool secondflag = true;

	public AudioClip mechsound;
	public AudioClip stopsound;
	
	// Use this for initialization
	void Start ()
	{
		isLocked = false;
		secondflag = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (modCounter == 0) {
			//trap door at bottom or stopped
			//audio.Stop();
			flag = true;
			if (secondflag) {
				secondflag = false;
				audio.clip = stopsound;
				audio.Play();
			}
		}
		
		
		if (modCounter == 1) {
			//trap door moving up
			Debug.Log("how many times is this playing");
			rotationCenter.Rotate (Vector3.down, rotationSpeed * Time.deltaTime);
			secondflag = true;

			if (flag) {
				flag = false;
				audio.clip = mechsound;
				audio.Play();
			}
		}
		
		if (modCounter == 2) {
			//trap door at top or stopped (preparing to move up)
			//audio.Stop();
			flag = true;
			if (secondflag) {
				secondflag = false;
				audio.clip = stopsound;
				audio.Play();
			}
			
		}
		
		if (modCounter == 3) {
			//trap door moving down
			rotationCenter.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
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
		}
	}
	public void Lock ()
	{
		isLocked = true;
	}
}
