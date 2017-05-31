using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text field;

	void Start()
	{
		Loop();
		Events.Log += Log;
	}
	void Loop()
	{
		CheckPhotos ();
		Invoke ("Loop", 1);
	}
	void CheckPhotos()
	{
		int totalPhotos = Data.Instance.photosManager.photos.Count;
		Events.Log ("Total " + totalPhotos);
	}
	void Log(string text)
	{
		field.text = text;
	}
}
