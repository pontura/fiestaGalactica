using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour {
	
	public states state;
	public enum states
	{
		IDLE,
		FLY,
		CONNECT
	}
	public StateFly fly;
	public StateConnected connect;
	Character character;

	void Start () {
		character = GetComponent<Character> ();
		fly.Init ();
	}
	public void ChangeState(states _state)
	{
		if (this.state == _state)
			return;
		
		switch (state) {

		case states.FLY:
			fly.Finish ();
			break;

		case states.CONNECT:
			connect.Finish ();
			break;
		}

		this.state = _state;
		connect.enabled = false;
		fly.enabled = false;

		switch (state) {

		case states.FLY:
			fly.enabled = true;
			fly.Init ();
			break;

		case states.CONNECT:
			connect.enabled = true;
			connect.Init ();
			break;
		}

	}
}
