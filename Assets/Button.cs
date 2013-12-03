using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseOver ()
	{
		renderer.material.color -= new Color (0.1F, 0, 0) * Time.deltaTime;
		Debug.Log ("mouseover");
	}
}
