using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	//variables to control door and aspects
	public bool unlocked;
	public Light doorLight;
	public int loadLevel;

	//material colors for door
	public Color lockedColor = Color.red;
	public Color readyColor = Color.green;
	public Color openColor = Color.black;

	void Start ()
	{
		//by default all doors are locked
		doorLight.light.color = lockedColor;
		unlocked = false;
		gameObject.collider.isTrigger = false;
	}

	void Update ()
	{
		
	}
	
	public void Unlock ()
	{
		//sets the color of the door to black and sets the color of the light to green 
		//gameObject.renderer.material.color = openColor;
		doorLight.light.color = readyColor;
		unlocked = true;
	}
	
	public void Open ()
	{
		gameObject.renderer.material.color = openColor;
		gameObject.collider.isTrigger = true;
	}

	public void OnTriggerEnter (Collider otherCollider)
	{
		if (otherCollider.name.Contains ("Player")) {
			Application.LoadLevel (loadLevel);
		}
	}
}

