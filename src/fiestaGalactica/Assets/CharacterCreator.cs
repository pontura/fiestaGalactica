using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour {

	public CharacterStyles styles;
	public Character cosmonauta;
	public Character alien1;
	public Character alien2;
	public Character alien3;
	public Character alien4;
	public Character selectedCharacter;

	void Start () {
		Reset ();
		Events.ChangeStyle += ChangeStyle;
		Events.ChangeAlien += ChangeAlien;
	}
	void Reset()
	{
		cosmonauta.gameObject.SetActive (false);
		alien1.gameObject.SetActive (false);
		alien2.gameObject.SetActive (false);
		alien3.gameObject.SetActive (false);
		alien4.gameObject.SetActive (false);
	}
	public void SetCharacter(int id)
	{
		Reset ();
		switch (id) {
		case 0: 
			selectedCharacter = cosmonauta;
			break;
		case 1: 
			selectedCharacter = alien1;
			break;
		case 2: 
			selectedCharacter = alien2;
			break;
		case 3: 
			selectedCharacter = alien3;
			break;
		case 4: 
			selectedCharacter = alien4;
			break;
		}
		GetComponent<WebcamPhoto> ().SetRawImage (selectedCharacter.head);
		selectedCharacter.gameObject.SetActive (true);
	}
	void ChangeStyle (int id, int id2) {
		styles.Change (id, id2);
	}
	void ChangeAlien(int characterID)
	{
		SetCharacter (characterID);
	}
}
