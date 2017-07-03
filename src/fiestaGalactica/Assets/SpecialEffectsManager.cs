using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour {

	public int timeToHappenFrom;
	public int timeToHappenTo;
	public int MinCharacters;

	public Robots robots;
	public Estacion estacion;

	private int sec = 0;
	private CharactersManager characterManager;
	public Transform mainCamera;
	bool isOn;
	public LightTrip lightTrip;
	public World world;
	int timeToHappen;

	void Start () {
		timeToHappen = Random.Range (timeToHappenFrom, timeToHappenTo);
		robots.gameObject.SetActive (false);
		estacion.gameObject.SetActive (false);
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
					timeToHappen = Random.Range (timeToHappenFrom, timeToHappenTo);
				}
			}
		}
		Invoke ("Loop", 1);
	}
	void Init ()
	{
		isOn = true;
		Events.OnSpecialEffect ();
		if(world.id == 3)
			StartCoroutine (InitRobot ());
		else
			StartCoroutine (InitEstacion ());
	}
	IEnumerator InitEstacion()
	{	
		estacion.gameObject.SetActive (true);
		Texture2D[] list = new Texture2D[characterManager.all.Count];
		for(int a=0; a<characterManager.all.Count; a++ )
			list [a] = characterManager.all[a];
		estacion.Init (list, mainCamera);
		yield return new WaitForSeconds (25);
		Events.OnLightTrip (true);
		yield return new WaitForSeconds (2);
		estacion.Reset ();
		estacion.gameObject.SetActive (false);
		world.OnChange ();
		yield return new WaitForSeconds (60);
		Restart ();
	}
	IEnumerator InitRobot()
	{	
		robots.gameObject.SetActive (true);
		Texture2D[] list = new Texture2D[characterManager.all.Count];
		for(int a=0; a<characterManager.all.Count; a++ )
			list [a] = characterManager.all[a];
		robots.Init (list, mainCamera);
		yield return new WaitForSeconds (25);
		Events.OnLightTrip (true);
		yield return new WaitForSeconds (1);
		robots.Reset ();
		robots.gameObject.SetActive (false);
		world.OnChange ();
		yield return new WaitForSeconds (60);
		Restart ();
	}
}
