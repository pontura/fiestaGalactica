using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFly : State {

	public float speed;
	public float floatSpeed;

	public bool onlyWalk;

	public float rotate;

	public flyTypes flyType;
	bool isOn;

	public enum flyTypes
	{
		FLY,
		FLOAT
	}

	public override void OnInit()
	{
		isOn = true;
		rotate = (float)( Random.Range (0, 400) - 200 ) / 10;

		CancelInvoke ();
		Loop ();

	}
	void Loop()
	{
		if (!isOn)
			return;
		if (character.states.state != StatesManager.states.FLY)
			return;
		if (Random.Range (0, 100) > 50)
			StartCoroutine (Flying ());
		else
			StartCoroutine (Floating ());
	}
	IEnumerator Flying()
	{
		if (onlyWalk) {
			flyType = flyTypes.FLY;
			anim.Play ("Walk");
			yield return new WaitForSeconds (Random.Range (3, 10));
			if (flyType == flyTypes.FLY)
				Loop ();
		} else {
			flyType = flyTypes.FLY;
			anim.Play ("FlightStart");
			yield return new WaitForSeconds (2);
			if (isOn && flyType == flyTypes.FLY)
				anim.Play ("Flight");
			yield return new WaitForSeconds (6);
			Loop ();
		}
	}
	IEnumerator Floating()
	{
		flyType = flyTypes.FLOAT;
		anim.Play ("Float");
		yield return new WaitForSeconds (5);
		Loop ();
	}
	public virtual void OnFinish()
	{
		StopCoroutine (Flying ());
		StopCoroutine (Floating ());
		isOn = false;
	}
	void Update () {
		
		if (!isOn)
			return;
		
		Vector3 pos = transform.localPosition;

		float newSpeed = speed;
		if (flyType == flyTypes.FLOAT)
			newSpeed = floatSpeed;

		float newRotate = rotate;
		if (flyType == flyTypes.FLOAT)
			newRotate = rotate/2;
		
		pos += (newSpeed * transform.up) * Time.deltaTime;
		Positionate(pos);

		Vector3 rot = transform.localEulerAngles;
		rot.z += newRotate * Time.deltaTime;
		Rotate (rot);
	}
}
