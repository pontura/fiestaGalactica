using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLightTrip : State {

	public float speed;
	bool isOn;
	public override void OnInit()
	{	
		isOn = true;
	}
	public override void OnFinish() 
	{	
		isOn = false;
	}
	void Update () {
		if (!isOn)
			return;
		Vector3 pos = transform.localPosition;		
		pos.z -= speed * Time.deltaTime;
		Positionate(pos);
	}
}
