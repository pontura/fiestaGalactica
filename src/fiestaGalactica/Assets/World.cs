using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	public int id;
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;

	void Start () {
		Reset ();
		SetActive (id);
	}
	void SetActive(int id)
	{
		Reset ();
		switch (id) {
		case 1:
			level1.SetActive (true);
			break;
		case 2:
			level2.SetActive (true);
			break;
		case 3:
			level3.SetActive (true);
			break;
		}
	}
	void Reset () {
		level1.SetActive (false);
		level2.SetActive (false);
		level3.SetActive (false);
	}
	public void OnChange()
	{
		id++;
		if (id > 3)
			id = 1;
		SetActive (id);
	}
}
