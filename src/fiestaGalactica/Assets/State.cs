using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

	Vector2 limits;
	Vector2 limitsRotate;

	[HideInInspector]
	public Animator anim;
	[HideInInspector]
	public Character character;

	public void Init()
	{
		character = GetComponent<Character> ();
		anim = GetComponent<Animator> ();

		if(Data.Instance != null)
			limits = Data.Instance.config.limits;

		OnInit ();
	}
	void OnDestroy()
	{
		StopAllCoroutines ();
	}
	public void Finish()
	{
		OnFinish ();
	}
	public virtual void OnInit() { }
	public virtual void OnFinish() { }

	public void Positionate(Vector3 pos)
	{		
		if (character.states.state == StatesManager.states.ABDUCTION) 
			return;
		
		if (pos.y > limits.x) {
			pos.y = -limits.x;
			pos = Repositionate (pos);
		} else if (pos.y < -limits.x) {
			pos.y = limits.x;
			pos = Repositionate (pos);
		}
		if (pos.x > limits.y) {
			pos.x = -limits.y;
			pos = Repositionate (pos);
		} else if (pos.x < -limits.y) {
			pos.x = limits.y;
			pos = Repositionate (pos);
		}
		transform.localPosition = pos;
	}
	Vector3 Repositionate(Vector3 pos)
	{		
		if (character.states.state == StatesManager.states.LIGHTTRIP) {
			return new Vector3 (0, 1000, 0);
		}
		int rand = Random.Range (0, 3);
		if (rand == 1) {
			pos.x /= 1.5f;
			pos.y /= 1.5f;
		} else if (rand == 2) {
			pos.x /= 1.6f;
			pos.y /= 1.6f;
		}else if (rand == 3) {
			pos.x /= 1.9f;
			pos.y /= 1.9f;
		}
		pos.z = rand * 20 * -1;
		return pos;
	}
	public void Rotate(Vector3 rot)
	{
		transform.localEulerAngles = rot;
	}
}
