using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSpecial : State {
		
	public float speed;
	public float floatSpeed;
	public float rotate;

	public override void OnInit()
	{
		rotate = (float)( Random.Range (0, 600) - 300 ) / 10;
		if (character.info.type == CharacterInfo.types.ASTRONAUTA) {			
			CancelInvoke ();
			Loop ();
		}		
	}
	void Loop()
	{
		StartCoroutine (Flying ());
	}
	IEnumerator Flying()
	{
		anim.Play ("FlightStart");
		yield return new WaitForSeconds (1.2f);
		anim.Play ("Flight");
		yield return new WaitForSeconds (4);
		Loop ();
	}

	public virtual void OnFinish()
	{
		StopCoroutine (Flying ());
	}
	void Update () {
		Vector3 pos = transform.localPosition;

		float newSpeed = speed;
		float newRotate = rotate;

		pos += (newSpeed * transform.up) * Time.deltaTime;
		Positionate(pos);

		Vector3 rot = transform.localEulerAngles;
		rot.z += newRotate * Time.deltaTime;
		Rotate (rot);
	}
}
