using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAbduction : State {

	bool isOn;
	Transform myParent;

	public override void OnInit()
	{	
		this.myParent = transform.parent;
		isOn = true;
		Invoke ("Reset", 3);
		anim.Play ("Launch");
	}
	public override void OnFinish() 
	{	
		isOn = false;
		transform.SetParent (myParent);
		character.transform.localScale = Vector3.one;
	}
	void Update () {
		if (isOn)
			return;
	}
	void Reset()
	{
		transform.localPosition = new Vector3 (0, 1000, 0);
	}
}
