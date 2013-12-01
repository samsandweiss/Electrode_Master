using UnityEngine;
using System.Collections;

public class UIItem : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Select ()
	{
		renderer.material.color = Color.red;
	}
}
