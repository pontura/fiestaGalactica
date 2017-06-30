using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrip : MonoBehaviour {

	public GameObject asset;
	public ParticleSystem[] particles;

	void Start () {
		asset.SetActive (false);
		Events.OnLightTrip += OnLightTrip;
	}

	public void OnLightTrip(bool isOn)
	{
		if(isOn)
			StartCoroutine (Animate ());
	}
	IEnumerator Animate()
	{
		asset.SetActive (true);
		asset.GetComponent<Animation> ().Play ("init");
		foreach (ParticleSystem ps in particles)
			ps.Play ();

		yield return new WaitForSeconds (20);

		asset.GetComponent<Animation> ().Play ("end");
		foreach (ParticleSystem ps in particles)
			ps.Stop ();

		Events.OnLightTrip (false);

		yield return new WaitForSeconds (5);
		asset.SetActive (false);

	}
}
