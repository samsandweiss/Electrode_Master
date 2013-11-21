using UnityEngine;
using System.Collections;

public class SwitchDoor : MonoBehaviour {
	public Door door;
	public bool activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Activate() {
		if (door.gameObject.GetComponent<Door>().unlocked == false) {
			door.gameObject.GetComponent<Door>().Unlock();
		} else {
			door.gameObject.GetComponent<Door>().Open();
		}
	}
}

