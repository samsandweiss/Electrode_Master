using UnityEngine;
using System.Collections;

public class InvisibleFloor : MonoBehaviour
{
	public int loadLevel;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
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
