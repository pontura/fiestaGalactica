using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

	public GameObject startingUI;
	public GameObject styles;
	public int id;
	public int totalStyles;

	void Start()
	{
		startingUI.SetActive (true);
		styles.SetActive (false);
		Events.OnPhotoTaken += OnPhotoTaken;
	}
	public void OnPhotoTaken()
	{
		startingUI.SetActive (false);
		styles.SetActive (true);
	}

	public void Next()
	{
		id++;
		if (id > totalStyles)
			id = 1;
		Events.ChangeStyle (id);
	}
	public void Prev()
	{
		id--;
		if (id < 1)
			id = totalStyles;
		Events.ChangeStyle (id);
	}
}
