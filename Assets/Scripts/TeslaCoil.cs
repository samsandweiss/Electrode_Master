using UnityEngine;
using System.Collections;

public class TeslaCoil : MonoBehaviour
{
	public ParticleEmitter emitter;
	void Start ()
	{
	}
	

	void Update ()
	{
	
	}

	void OnTriggerStay (Collider otherCollider)
	{
		if (otherCollider.name.Contains ("Player")) {
			Debug.Log ("Tesla coil is being hit");
			//otherCollider.GetComponent<LightningBolt> ().target = GameObject.transform;
			emitter.active = true;
		}
	}

	void OnTriggerExit (Collider otherCollider)
	{
		if (otherCollider.name.Contains ("Player")) {
			emitter.active = false;
		}
	}
}
