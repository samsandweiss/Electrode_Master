﻿using UnityEngine;
using System.Collections;

//This is the script for the main menu. it allows the world to pan from letf to right.

using UnityEngine;
using System.Collections;

//This is the script for the main menu. it allows the world to pan from letf to right.

public class MoveCamera : MonoBehaviour
{
	public TextMesh title;
	public TextMesh play;
	public TextMesh credits;
	public TextMesh quit;
	public bool hasBeenPressed;
	public float waitTime;
	
	public Color selected;
	public Color deselected;
	
	public int selectedText = 0;
	public float movementSpeed = 1.0f;
	private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
	
	// Use this for initialization
	void Start ()
	{
		
		selectedText = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		movement = Vector3.left * movementSpeed * Time.deltaTime;
		gameObject.transform.Translate (movement);
		
		if (!hasBeenPressed) {
			if (Input.GetAxis ("Vertical") < -0.9) {
				hasBeenPressed = true;
				StartCoroutine (Wait ());
				
				if (selectedText < 2) {
					selectedText++;
				}  else {
					selectedText = 0;
				}
			}  else if (Input.GetAxis ("Vertical") > 0.9) {
				hasBeenPressed = true;
				StartCoroutine (Wait ());
				if (selectedText > 0) {
					selectedText--;
				}  else {
					selectedText = 2;
				}
			}
		}
		
		if (Input.GetButtonDown ("Jump") && selectedText == 0) {
			Application.LoadLevel (1);
		}
		
		if (Input.GetButtonDown ("Jump") && selectedText == 2) {
			Application.Quit ();
		}
		
		if (selectedText == 0) {
			title.renderer.material.color = deselected;
			play.renderer.material.color = selected;
			credits.renderer.material.color = deselected;
			quit.renderer.material.color = deselected;
		}
		
		if (selectedText == 1) {
			title.renderer.material.color = deselected;
			play.renderer.material.color = deselected;
			credits.renderer.material.color = selected;
			quit.renderer.material.color = deselected;
		}
		
		if (selectedText == 2) {
			title.renderer.material.color = deselected;
			play.renderer.material.color = deselected;
			credits.renderer.material.color = deselected;
			quit.renderer.material.color = selected;
		}  
	}
	
	void OnTriggerEnter (Collider otherCollider)
	{
		if (otherCollider.gameObject.name.Contains ("End")) {
			Application.LoadLevel (0);
		}
		
	}
	
	IEnumerator Wait ()
	{
		
		yield return new WaitForSeconds (waitTime);
		hasBeenPressed = false;
	}
}

