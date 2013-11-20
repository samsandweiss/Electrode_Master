using UnityEngine;
using System.Collections;

public class sTrapDoor : MonoBehaviour {
	public TrapDoor trapdoor;
	public bool activated;
	public bool trololo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Activate() {
		//this comment was added to troll everyone. trololololololololololololololollolololollololol
		trapdoor.gameObject.GetComponent<TrapDoor>().Activate();
	}
}
