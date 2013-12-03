using UnityEngine;
using System.Collections;

public class InvisibleFloor : MonoBehaviour
{
	//the class is for reseting levels after falls. 
	public int loadLevel;
	
	void Start ()
	{
	
	}

	void Update ()
	{
	
	}

	public void OnTriggerEnter (Collider otherCollider)
	{
		if (otherCollider.name.Contains ("Player")) {
			Application.LoadLevel (loadLevel);
			Debug.Log ("Loading Level: " + loadLevel);
		}
	}
}
