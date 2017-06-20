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

	void Awake()
	{
		character = GetComponent<Character> ();
		anim = GetComponent<Animator> ();
		limits = new Vector2 (8, 30);
	}
	void Start()
	{

	}
	public void Init()
	{
		OnInit ();
	}
	public void Finish()
	{
		OnFinish ();
	}
	public virtual void OnInit() { }
	public virtual void OnFinish() { }

	public void Positionate(Vector3 pos)
	{
		bool repositionated = false;
		if (pos.y > limits.x) {
			repositionated = true;
			pos.y = -limits.x;
		} else if (pos.y < -limits.x) {
			repositionated = true;
			pos.y = limits.x;
		}
		
		if (pos.x > limits.y) {
			repositionated = true;
			pos.x = -limits.y;
		} else if (pos.x < -limits.y) {
			repositionated = true;
			pos.x = limits.y;
		}
		if (repositionated)
			pos.z = Random.Range (0, 3) * 20 * -1;
		transform.localPosition = pos;
	}
	public void Rotate(Vector3 rot)
	{
		transform.localEulerAngles = rot;
	}
}
