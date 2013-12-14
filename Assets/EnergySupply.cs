using UnityEngine;
using System.Collections;

public class EnergySupply : MonoBehaviour
{

	public Player player;
	public float currentScore;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentScore = player.GetComponent<Player> ().chargeValue;
		GetComponent<TextMesh> ().text = "E N E R G Y  S U P P L Y : " + currentScore;

	}
}
