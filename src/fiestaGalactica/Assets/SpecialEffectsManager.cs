using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour {

	public int timeToHappen = 60;
	public int MinCharacters = 10;
	public Robots robots;
	private int sec = 0;
	private CharactersManager characterManager;
	public Transform mainCamera;

	void Start () {
		sec = 0;
		characterManager = GetComponent<CharactersManager> ();
		Loop ();
	}
	void Loop()
	{
		sec++;
		if (sec >= timeToHappen) {
			if (characterManager.all.Count > MinCharacters) {
				Init ();
			}
		}
		Invoke ("Loop", 1);
	}
	void Init()
	{
		sec = -1000;
		Texture2D[] list = new Texture2D[4];

		for(int a=0; a<characterManager.all.Count; a++ )
			list [a] = characterManager.all[a];

		Events.OnSpecialEffect ();
		robots.Init (list, mainCamera);
		list = null;
	}
}
