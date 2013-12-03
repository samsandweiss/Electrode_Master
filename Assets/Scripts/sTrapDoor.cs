using UnityEngine;
using System.Collections;

public class sTrapDoor : MonoBehaviour {

	public TrapDoor trapdoor;
	public bool activated;


	void Start () {
	
	}
	

	void Update () {
	
	}
	
	public void Activate() {
		trapdoor.gameObject.GetComponent<TrapDoor>().Activate();
	}
}
