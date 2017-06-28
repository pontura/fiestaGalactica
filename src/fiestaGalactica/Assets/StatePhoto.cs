using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePhoto : State {

	public override void OnInit()
	{
		anim.Play ("Photo");
	}
}
