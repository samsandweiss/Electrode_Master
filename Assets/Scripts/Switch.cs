using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	public TrapDoor trapdoor;
	public bool activated;

	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (trapdoor.gameObject.GetComponent<TrapDoor>().upPosition == true) {
			activated = true;	
		}
	}
	
	public void Activate() {
		if (activated == false) {
			trapdoor.gameObject.GetComponent<TrapDoor>().Activate();
		}
	}
}
