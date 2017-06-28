using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLaunch : State {

	Vector3 dest;
	float timeToLaunch;
	bool animate;

	public override void OnInit()
	{
		float rotate;
		float timeToFly = 3;
		if (character.info.type == CharacterInfo.types.ASTRONAUTA) {
			rotate = (float)(Random.Range (0, -100));
			animate = true;
			dest = transform.localPosition;
			dest.x += Random.Range (4, 12);
			timeToLaunch = (float)Random.Range (2, 20) / 300;
		} else {
			timeToFly = 2f;
			rotate = (float)( Random.Range (1, 70) );
		}
		transform.localEulerAngles = new Vector3(0,0,rotate);
		anim.Play ("Launch");
		Invoke ("Done", timeToFly);
	}
	void Update()
	{		
		if(animate)
			transform.localPosition = Vector3.Lerp (transform.localPosition, dest, timeToLaunch);
	}
	void Done()
	{
		if (character.states.state == StatesManager.states.SPECIAL)
			character.states.ChangeState (StatesManager.states.SPECIAL);
		else
			character.states.ChangeState (StatesManager.states.FLY);
	}

}
