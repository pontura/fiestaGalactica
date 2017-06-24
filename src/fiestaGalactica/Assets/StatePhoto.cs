using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePhoto : State {

	public override void OnInit()
	{
		print ("Photo");
		anim.Play ("Photo");
	}
}
