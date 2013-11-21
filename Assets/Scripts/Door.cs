using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool unlocked;
	public string lockedText;
	public string unlockedText;
	public string openText;
	public Light doorLight;
	public TextMesh doorText;
	
	public Color lockedColor = Color.red;
	public Color readyColor = Color.green;
	public Color openColor = Color.black;
	// Use this for initialization
	void Start () {
		doorLight.light.color = lockedColor;
		unlocked = false;
		gameObject.collider.isTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Unlock () {
		//sets the color of the door to black and sets the color of the light to green 
		//gameObject.renderer.material.color = openColor;
		doorLight.light.color = readyColor;
		unlocked = true;
	}
	
	public void Open () {
		gameObject.renderer.material.color = openColor;
		gameObject.collider.isTrigger = true;
	}
}

