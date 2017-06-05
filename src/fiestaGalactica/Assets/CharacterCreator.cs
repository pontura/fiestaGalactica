using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour {

	public CharacterStyles styles;

	void Start () {
		Events.ChangeStyle += ChangeStyle;
	}

	void ChangeStyle (int id) {
		styles.Change (id);
	}
}
