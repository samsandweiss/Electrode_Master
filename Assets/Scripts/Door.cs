using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open;
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	 
	public void Open () {
		//sets the color of the door to black and sets the color of the light to green 
		//gameObject.renderer.material.color = openColor;
		doorLight.light.color = readyColor;
		open = true;
		
	}
}
