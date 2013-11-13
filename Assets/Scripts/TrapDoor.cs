using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour
{
	public Transform rotationCenter;
	public int rotationSpeed = 50;
	public bool upPosition;
	public bool downPosition;
	public bool movingForward;
	public bool isActivated;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (movingForward) {
			//moving forward code
			if (rotationCenter.eulerAngles.z >= 360) {
				upPosition = true;
			} else {
				if (isActivated) {
					rotationCenter.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
					upPosition = false;	
				}
			}
		} else {
			//moving backward code
			if (rotationCenter.eulerAngles.z <= 270) {
				downPosition = true;
			} else {
				if (isActivated) {
					rotationCenter.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
					downPosition = false;	
				}
			}
		}
		
		
		
	}
	
	public void Activate ()
	{
		isActivated = true;
		
		if (movingForward)
			movingForward = false;
		else
			movingForward = true;
		
//		if (upPosition == false) {
//			transform.RotateAround(rotationCenter.position, Vector3.forward, rotationSpeed * Time.deltaTime);	
//		} 
	}
}
