﻿using UnityEngine;
using System.Collections;

public class TeslaCoil : MonoBehaviour
{
	public ParticleEmitter emitter;
	public AudioClip teslainactive;
	public AudioClip teslaactive;

	void Start ()
	{
		audio.clip = teslainactive;
		audio.Play();
	}
	

	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider otherCollider) 
	{
		if (otherCollider.name.Contains ("Player") && otherCollider.GetComponent<Player> ().chargeValue < otherCollider.GetComponent<Player> ().maxChargeValue) {
		audio.clip = teslaactive;
		audio.Play();
		}
	}

	void OnTriggerStay (Collider otherCollider)
	{
		if (otherCollider.name.Contains ("Player") && otherCollider.GetComponent<Player> ().chargeValue < otherCollider.GetComponent<Player> ().maxChargeValue) {
			Debug.Log ("Tesla coil is being hit");
		
			//otherCollider.GetComponent<LightningBolt> ().target = GameObject.transform;
			emitter.active = true;

		}
	}

	void OnTriggerExit (Collider otherCollider)
	{
		if (otherCollider.name.Contains ("Player")) {
			emitter.active = false;
			audio.clip = teslainactive;
			audio.Play();
		}
	}
}
