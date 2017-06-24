using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour {
	
	public states state;
	public enum states
	{
		LAUNCH,
		FLY,
		CONNECT,
		PHOTO
	}
	public StateFly fly;
	public StateConnected connect;
	public StatePhoto photo;
	public StateLaunch launch;

	public State activeState;
	Character character;

	void Awake () {
		character = GetComponent<Character> ();

		if (activeState != null) {
			activeState.enabled = true;
			activeState.Init ();
		}
	}
	void Reset()
	{
		connect.enabled = false;
		fly.enabled = false;
		photo.enabled = false;
		launch.enabled = false;
	}
	public void ChangeState(states _state)
	{
		//if (this.state == _state)
			//return;
		
		switch (state) {

		case states.LAUNCH:
			launch.Finish ();
			break;

		case states.FLY:
			fly.Finish ();
			break;

		case states.CONNECT:
			connect.Finish ();
			break;
		}
		Reset ();
		this.state = _state;


		switch (state) {
		case states.PHOTO:
			photo.enabled = true;
			photo.Init ();
			break;
		case states.LAUNCH:
			launch.enabled = true;
			launch.Init ();
			break;
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
