using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {

	public Sprite sprite;

	public types type;
	public enum types
	{
		ASTRONAUTA,
		ALIEN1,
		ALIEN2,
		ALIEN3
	}
	public int styleHead;
	public int styleBody;

}
