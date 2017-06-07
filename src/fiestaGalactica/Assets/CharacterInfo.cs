using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {

	[HideInInspector]
	public Texture2D texture2d;

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
