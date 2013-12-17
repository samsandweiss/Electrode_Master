using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour
{
	public int levelToLoad;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetButtonDown ("Jump")) {
			Debug.Log ("Should load new level");
			Application.LoadLevel (levelToLoad);
		}

		if (Input.GetButtonDown ("Back")) {
			Debug.Log ("Should load menu");
			Application.LoadLevel (0);
		}
	
	}
}
