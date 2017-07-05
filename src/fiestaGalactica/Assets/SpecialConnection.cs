using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialConnection : MonoBehaviour {

	public bool isEstacion;
	void Start () {

	}
	void OnTriggerEnter(Collider other)
	{		
		Character character = null;
		if(other.GetComponent<HandConnection> ())
			character = other.GetComponent<HandConnection> ().character;

		if (character == null)
			return;
	
		other.GetComponent<HandConnection> ().enabled = false;
		Events.OnAbduction (character);

		character.states.ChangeState (StatesManager.states.ABDUCTION);

		if (isEstacion) {
			Vector3 pos = Vector3.zero;
			pos.y += 1f;
			character.transform.SetParent (transform.parent);
			character.transform.localPosition = pos;
			character.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
			character.transform.localEulerAngles = Vector3.zero;
		}

	}
}
