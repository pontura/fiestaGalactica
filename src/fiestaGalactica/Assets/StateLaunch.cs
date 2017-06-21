using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLaunch : State {

	public override void OnInit()
	{
		float rotate = (float)( Random.Range (0, 100) - 50 );
		transform.localEulerAngles = new Vector3(0,0,rotate);
		anim.Play ("Launch");
		Invoke ("Done", 4f);
	}
	void Done()
	{
		character.states.ChangeState (StatesManager.states.FLY);
	}

}
