using System.Collections;
using UnityEngine;

public class Pause : MonoBehaviour
{
	bool paused = false;
	public bool hasBeenPressed;
	public float waitTime;
	public int selectedText ;
	public Color selected;
	public Color deselected;
	public TextMesh title;
	public TextMesh play;
	public TextMesh credits;
	public TextMesh quit;
	public int currentLevel;

	
	void Update ()
	{
		Debug.Log (selectedText);
		if (Input.GetButtonDown ("Fire2"))
			Application.LoadLevel (currentLevel);
		//paused = togglePause ();
	}
	
//	void OnGUI ()
//	{
//		if (paused) {
//			activateText ();
//			if (Time.timeScale == 0f) {
//				if (!hasBeenPressed) {
//					if (Input.GetAxis ("Vertical") < -0.9) {
//						hasBeenPressed = true;
//						StartCoroutine (Wait ());
//						
//						if (selectedText < 2) {
//							selectedText++;
//						} else {
//							selectedText = 0;
//						}
//					} else if (Input.GetAxis ("Vertical") > 0.9) {
//						hasBeenPressed = true;
//						StartCoroutine (Wait ());
//						if (selectedText > 0) {
//							selectedText--;
//						} else {
//							selectedText = 2;
//						}
//					}
//				}
//				
//				//resume is highlighted
//				if (Input.GetButtonDown ("Jump") && selectedText == 0) {
//					paused = togglePause ();
//				}
//				
//				//restart is highlighted
//				if (Input.GetButtonDown ("Jump") && selectedText == 1) {
//					Application.LoadLevel (currentLevel);
//					paused = togglePause ();
//				}
//				
//				//quit is highlighted
//				if (Input.GetButtonDown ("Jump") && selectedText == 2) {
//					Application.Quit ();
//				}
//				
//				
//				if (selectedText == 0) {
//					title.renderer.material.color = deselected;
//					play.renderer.material.color = selected;
//					credits.renderer.material.color = deselected;
//					quit.renderer.material.color = deselected;
//				}
//				
//				if (selectedText == 1) {
//					title.renderer.material.color = deselected;
//					play.renderer.material.color = deselected;
//					credits.renderer.material.color = selected;
//					quit.renderer.material.color = deselected;
//				}
//				
//				if (selectedText == 2) {
//					title.renderer.material.color = deselected;
//					play.renderer.material.color = deselected;
//					credits.renderer.material.color = deselected;
//					quit.renderer.material.color = selected;
//				}  
//			}
//
//
//
//		}
//	}
//	
//	bool togglePause ()
//	{
//		if (Time.timeScale == 0f) {
//			deactivateText ();
//			Time.timeScale = 1f;
//			return(false);
//		} else {
//			Time.timeScale = 0f;
//			return(true);    
//			activateText ();
//
//		}
//	}
//
//	void activateText ()
//	{
//		title.active = true;
//		play.active = true;
//		credits.active = true;
//		quit.active = true;
//	}
//
//	void deactivateText ()
//	{
//		Debug.Log ("text should be deactivated");
//		title.active = false;
//		play.active = false;
//		credits.active = false;
//		quit.active = false;
//	}
//
//	IEnumerator Wait ()
//	{
//		yield return new WaitForSeconds (waitTime);
//		hasBeenPressed = false;
//	}
}