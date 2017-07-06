using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersConnection : MonoBehaviour {

	private float speed = 2;
	Character ch1;
	Character ch2;
	Vector2 limits;
	Transform container;

	Vector3 pos1;
	Vector3 pos2;

	void Awake()
	{
		limits = new Vector2 (8, 30);
	}

	public void Init (Character ch1, Character ch2)
	{
		this.ch1 = ch1;
		this.ch2 = ch2;

		container = ch1.transform.parent;

		ch1.transform.SetParent (transform);
		ch2.transform.SetParent (transform);

		pos1 = ch1.transform.localPosition;
		pos2 = ch2.transform.localPosition;

		pos1.x = 0.7f;
		pos2.x = -0.7f;

		pos1.y = 0; pos2.y = 0;
		pos1.z = 0; pos2.z = 0;

		Invoke ("Reset", 5.3f);

		Events.OnHands ((int)transform.position.x);
	}
	void Reset()
	{
		ch1.transform.parent = container;
		ch2.transform.parent = container;

		ch1.states.ChangeState (StatesManager.states.FLY);
		ch2.states.ChangeState (StatesManager.states.FLY);

		Destroy (gameObject);
	}
	void Update()
	{
		ch1.transform.localPosition = Vector3.Lerp (ch1.transform.localPosition, pos1, 0.1f);
		ch2.transform.localPosition = Vector3.Lerp (ch2.transform.localPosition, pos2, 0.1f);

		ch1.transform.localEulerAngles =	Vector3.Lerp (ch1.transform.localPosition, Vector3.zero, 0.1f);
		ch2.transform.localEulerAngles =  Vector3.Lerp (ch1.transform.localPosition, Vector3.zero, 0.1f);


		Vector3 rot = transform.localEulerAngles;
		rot.z += Random.Range (20, 80) * Time.deltaTime;
		transform.localEulerAngles = rot;

		Vector3 pos = transform.localPosition;
		pos += (Random.Range (10, 100) / 90 * transform.up) * Time.deltaTime;
		Positionate (pos);
	}
	public void Positionate(Vector3 pos)
	{
		if (pos.y > limits.x)
			pos.y = -limits.x;
		else if (pos.y < -limits.x)
			pos.y  = limits.x;

		if (pos.x > limits.y)
			pos.x = -limits.y;
		else if (pos.x < -limits.y)
			pos.x  = limits.y;

		transform.localPosition = pos;
	}

}
