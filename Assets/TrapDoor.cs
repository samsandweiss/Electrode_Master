using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour {
	public Transform rotationCenter;
	public int rotationSpeed = 50;
	public bool activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
			
	
	public void Activate() {
		if (gameObject.transform.eulerAngles.z <= 90) {
			transform.RotateAround(rotationCenter.position, Vector3.forward, rotationSpeed * Time.deltaTime);	
		}
	}
}
