using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour {

	public int timeToHappen;

	public Robot robot;

	private int sec = 0;
	private CharactersManager characterManager;

	void Start () {
		sec = 0;
		characterManager = GetComponent<CharactersManager> ();
		Loop ();
	}
	void Loop()
	{
		sec++;
		if (sec >= timeToHappen) {
			if (characterManager.all.Count > 3) {
				Init ();
			}
		}
		Invoke ("Loop", 1);
	}
	void Init()
	{
		sec = -10;
		Texture2D[] list = new Texture2D[4];

		for(int a=0; a<characterManager.all.Count; a++ )
			list [a] = characterManager.all[a];

		Events.OnSpecialEffect ();
		robot.Init (list);
		list = null;
	}
}
