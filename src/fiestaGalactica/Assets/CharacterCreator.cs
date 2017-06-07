using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour {

	public CharacterStyles styles;

	void Start () {
		Events.ChangeStyle += ChangeStyle;
	}

	void ChangeStyle (int id, int id2) {
		styles.Change (id, id2);
	}
}
