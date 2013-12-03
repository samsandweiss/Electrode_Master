using UnityEngine;
using System.Collections;

//this code is for the switch on doors

public class SwitchDoor : MonoBehaviour {
	public Door door;
	public bool activated;
	

	void Start () {
		
	}

	void Update () {
		
	}
	
	public void Activate() {
		if (door.gameObject.GetComponent<Door>().unlocked == false) {
			door.gameObject.GetComponent<Door>().Unlock();
		}  else {
			door.gameObject.GetComponent<Door>().Open();
		}
	}
}


