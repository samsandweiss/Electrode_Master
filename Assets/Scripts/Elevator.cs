using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	private int state= 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 1) {
			//move elevator down
		}
		if (state == 3) {
			//move elevator up
		}
		
			
		
	
	}
	
	void onTriggerStay () {
		//if elevator hits bottom
		//then state ++ and set bool elevator bottom to true
		
		//if elevator hits top
		//then state ++ elevator movement and se
		
		
	
	}
	
	void activate() {
		state ++;
			if (state > 3) {
				state = 0;
			}
}
}
