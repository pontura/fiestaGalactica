using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion: MonoBehaviour {

	public GameObject[] all;

	public void Init(int id)
	{
		int theID = 0;
		foreach (GameObject go in all) {
			
			if(theID == id)
				go.SetActive (true);
			else
				go.SetActive (false);
			
			theID++;
		}
		Invoke ("Reset", 2);
		Events.OnFireworks ((int)transform.position.x);
	}
	void Reset()
	{
		Destroy (this.gameObject);
	}
}
