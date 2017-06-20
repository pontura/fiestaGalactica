using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateConnected : State {

	public HandConnection handConnection;

	public override void OnFinish() 
	{ 
		handConnection.enabled = true;
	}
}
