using UnityEngine;
using System.Collections;

public class TeslaCoil : MonoBehaviour {
	public TextMesh coilText;
	public string activatedText;

	// Use this for initialization
	void Start () {
		coilText.gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ShowMessage () {
		coilText.gameObject.renderer.enabled = true;
		coilText.GetComponent<TextMesh>().text = activatedText;
	}
	
	public void HideMessage () {
		coilText.gameObject.renderer.enabled = false;
	}
}
