using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateConnected : State {

	public HandConnection handConnection;

	public override void OnInit() 
	{ 
		anim.Play("Hands",0,0);
	}
	public override void OnFinish() 
	{ 
		handConnection.enabled = true;
	}
}
