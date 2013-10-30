using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open;
	public string lockedText;
	public string unlockedText;
	public string openText;
	public Light doorLight;
	public TextMesh doorText;
	
	public Color readyColor = Color.green;
	public Color openColor = Color.black;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (open) {
			doorText.GetComponent<TextMesh>().text = openText;
		}
	}
	
	public void Open () {
		//sets the color of the door to black and sets the color of the light to green 
		gameObject.renderer.material.color = openColor;
		doorLight.light.color = readyColor;
		open = true;
		
	}
	
	public void ShowLockedMessage () {
		doorText.gameObject.renderer.enabled = true;
		doorText.GetComponent<TextMesh>().text = lockedText;
	}
	
	public void ShowUnlockedMessage () {
		doorText.gameObject.renderer.enabled = true;
		doorText.GetComponent<TextMesh>().text = unlockedText;
	}
	
	public void HideMessage () {
		doorText.gameObject.renderer.enabled = false;
	}
}
