﻿using UnityEngine;
using System.Collections;

public class sTrapDoor : MonoBehaviour {
	public TrapDoor trapdoor;
	public bool activated;
	public int trapDoorChrg = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Activate() {
		trapdoor.gameObject.GetComponent<TrapDoor>().Activate();
	}
}
