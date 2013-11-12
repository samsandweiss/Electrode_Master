using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour {
	public Transform rotationCenter;
	public int rotationSpeed = 50;
	public bool upPosition;

	// Use this for initialization
	void Start () {
		upPosition = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.eulerAngles.z >= 90) {
			upPosition = true;
		} else {
			upPosition = false;	
		}
		
	}
			
	
	public void Activate() {
		if (upPosition == false) {
			transform.RotateAround(rotationCenter.position, Vector3.forward, rotationSpeed * Time.deltaTime);
		}
	}
}
