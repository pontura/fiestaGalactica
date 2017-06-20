using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFly : State {

	public float speed;
	public float rotate;

	public override void OnInit()
	{
		rotate = (float)( Random.Range (0, 400) - 200 ) / 10;
		anim.Play ("FlightStart");
		CancelInvoke ();
		Invoke ("Loop", 1.5f);
	}
	void Loop()
	{
		anim.Play ("Flight");
		Invoke ("OnInit", 2);
	}
	public virtual void OnFinish()
	{
		CancelInvoke ();
	}
	void Update () {
		Vector3 pos = transform.localPosition;
		pos += (speed * transform.up) * Time.deltaTime;
		Positionate(pos);

		Vector3 rot = transform.localEulerAngles;
		rot.z += rotate * Time.deltaTime;
		Rotate (rot);
	}
}
