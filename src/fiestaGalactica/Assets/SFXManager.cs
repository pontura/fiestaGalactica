using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip specialTheme;

	public AudioClip fireworks;
	public AudioClip robots;

	public AudioClip hands;

	public AudioClip cosmonautaImpulsa1;
	public AudioClip cosmonautaImpulsa2;
	public AudioClip cosmonautaImpulsa3;

	public AudioClip SFXAlien3Walk;
	public AudioClip SFXAlien1Float;
	public AudioClip SFXAlien1Walk;

	public AudioClip lightTrip;
	public AudioClip launchAlien;
	public AudioClip launchCosmonauta;

	public AudioSource asMid;
	public AudioSource asLeft;
	public AudioSource asRight;

	public AudioSource asCosmonautas1;
	public AudioSource asCosmonautas2;
	public AudioSource asCosmonautas3;

	public AudioSource asAlien1;
	public AudioSource asAlien2;
	public AudioSource asAlien3;

	int asCosmonautasID;
	bool isLightTripOn;

	void Start () {		
		asCosmonautasID = 1;
		Events.OnSFXAction += OnSFXAction;
		Events.OnLightTrip += OnLightTrip;
		Events.OnSpecialEffect += OnSpecialEffect;
		Events.OnLaunch += OnLaunch;
		Events.OnFireworks += OnFireworks;
		Events.OnRobotStep += OnRobotStep;

		Events.OnHands += OnHands;
		Events.OnMusic += OnMusic;

		OnMusic ();
	}
	void OnSpecialEffect()
	{
		asMid.clip = specialTheme;
		asMid.Play ();
	}
	void OnMusic()
	{
		asMid.clip = mainTheme;
		asMid.Play ();
	}
	void OnHands(int _x)
	{
		OnSFX (hands, _x);
	}
	void OnFireworks(int _x)
	{
		OnSFX (fireworks, _x);
	}
	void OnRobotStep(int _x)
	{
		OnSFX (robots, _x);
	}
	void OnLightTrip(bool isOn)
	{
		isLightTripOn = isOn;

		if (isOn) {
			asMid.clip = lightTrip;
			asMid.Play ();
		} else {
			OnMusic ();
		}
	}
	void OnLaunch(CharacterInfo.types type)
	{
		if (type == CharacterInfo.types.ASTRONAUTA)
			OnSFX (launchCosmonauta, -1);
		else
			OnSFX (launchAlien, 1);
	}



	void OnSFXAction(string clipName)
	{
		if (clipName == "SFXAlien3Walk") {
			asAlien1.clip = SFXAlien3Walk;
			asAlien1.Play ();
		} else if (clipName == "SFXAlien1Float") {
			asAlien2.clip = SFXAlien1Float;
			asAlien2.Play ();
		} else if (clipName == "SFXAlien1Walk") {
			asAlien3.clip = SFXAlien1Walk;
			asAlien3.Play ();
		} else if (clipName == "cosmonautaImpulsa") {
			asCosmonautasID++;
			if (asCosmonautasID > 3)
				asCosmonautasID = 1;
			
			if (asCosmonautasID == 1) {
				asCosmonautas1.clip = cosmonautaImpulsa1;
				asCosmonautas1.Play ();
			} else if (asCosmonautasID == 2) {
				asCosmonautas2.clip = cosmonautaImpulsa2;
				asCosmonautas2.Play ();
			} else {
				asCosmonautas3.clip = cosmonautaImpulsa3;
				asCosmonautas3.Play ();
			}
		}
	}
	void OnSFX (AudioClip clipName, int _x) {
		
		if (isLightTripOn)
			return;

		print ("sonido: " + clipName + " X: " + _x);

		AudioSource audioSource;
		if(_x<0)
			audioSource = asLeft;
		else
			audioSource = asRight;
		
		audioSource.clip = clipName;		
		audioSource.Play ();
	}
}
