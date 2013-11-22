using UnityEngine;
using System.Collections;

public class SwitchElevator : MonoBehaviour {
	public Elevator elevator;
	public bool activated;
	public int ElevatorChrg = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Activate() {
		elevator.gameObject.GetComponent<Elevator>().Activate();
	}
}

