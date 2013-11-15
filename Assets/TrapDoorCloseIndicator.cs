using UnityEngine;
using System.Collections;

public class TrapDoorCloseIndicator : MonoBehaviour {
	public TrapDoor trapDoor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider otherCollider) {
		
			if (otherCollider.gameObject.name.Contains ("Player")) {
				Debug.Log("Door should be closing");
				trapDoor.GetComponent<TrapDoor>().Activate();
		}
	}
}
