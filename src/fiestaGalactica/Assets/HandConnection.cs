using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandConnection : MonoBehaviour {
	
	public Character character;

	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.GetComponent<HandConnection> ()) {
			if (character.states.state == StatesManager.states.SPECIAL || other.GetComponent<HandConnection> ().character.states.state == StatesManager.states.SPECIAL)
				return;
			other.GetComponent<HandConnection> ().enabled = false;
			enabled = false;
			Events.OnConnectCharacters (character.transform.localPosition, character, other.GetComponent<HandConnection> ().character);
		}
	}
}
