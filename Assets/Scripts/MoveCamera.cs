using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	public TextMesh title;
	public TextMesh play;
	public TextMesh credits;
	public TextMesh quit;

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

//		Debug.Log (selectedText);
//		if (Input.GetButtonDown ("Vertical")) {
//			if (selectedText < 2) {
//				selectedText++;
//			} else {
//				selectedText = 0;
//			}
//		}
//
//		if (Input.GetAxis ("Vertical") < 0) {
//			if (selectedText < 2) {
//				selectedText++;
//			} else {
//				selectedText = 0;
//			}
//		}

		if (Input.GetAxis ("Vertical") < 0) {
			if (selectedText < 2) {
				selectedText++;
			} else {
				selectedText = 0;
			}
		}

		if (Input.GetAxis ("Vertical") > 0) {
			if (selectedText > 0) {
				selectedText--;
			} else {
				selectedText = 2;
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
}
