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
	bool isOn;

	void Start () {
		robots.gameObject.SetActive (false);
		characterManager = GetComponent<CharactersManager> ();
		Restart ();
		Loop ();
	}
	void Restart()
	{
		isOn = false;
		sec = 0;
	}
	void Loop()
	{		
		if (!isOn) {
			sec++;
			if (sec >= timeToHappen) {
				if (characterManager.all.Count > MinCharacters) {
					Init ();
				}
			}
		}
		Invoke ("Loop", 1);
	}
	void Init ()
	{
		isOn = true;
		Events.OnSpecialEffect ();
		StartCoroutine (InitRobot ());
	}
	IEnumerator InitRobot()
	{	
		robots.gameObject.SetActive (true);
		Texture2D[] list = new Texture2D[4];
		for(int a=0; a<characterManager.all.Count; a++ )
			list [a] = characterManager.all[a];
		robots.Init (list, mainCamera);
		list = null;
		yield return new WaitForSeconds (40);
		robots.gameObject.SetActive (false);
		Restart ();
	}
}
