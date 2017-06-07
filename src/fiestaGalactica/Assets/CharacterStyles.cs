using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStyles : MonoBehaviour {

	public SpriteRenderer casco;
	public SpriteRenderer body;

	public SpriteRenderer[] arms;
	public SpriteRenderer[] legs;

	void Start () {
		
	}

	public void Change(int id, int id2) {
		
		string fileField = "Cosmonauta/ropa_";
		print (fileField + id + "_CASCO1");

		casco.sprite = Resources.Load<Sprite> (fileField + id + "_CASCO1");
		body.sprite = Resources.Load<Sprite> (fileField + id2 + "_BODY");

		foreach (SpriteRenderer sr in arms)
			sr.sprite = Resources.Load<Sprite> (fileField + id2 + "_ARM");
		foreach (SpriteRenderer sr in legs)
			sr.sprite = Resources.Load<Sprite> (fileField + id2 + "_LEG");
	}
	
}
