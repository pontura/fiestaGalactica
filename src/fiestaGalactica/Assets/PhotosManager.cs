using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class PhotosManager : MonoBehaviour {

	public List<string> files;

	string charactersPath;

	void Start()
	{
		charactersPath = Application.streamingAssetsPath + "/characters/";
		GetAllFiles ();
		Invoke ("all", 1);
	}
	void all()
	{
		Events.Log("Son: " + files.Count);
	}
	void GetAllFiles()
	{
		foreach(string file in Utils.GetAllFilesIn(charactersPath))
		{
			files.Add (file);
			StartCoroutine( LoadSprite(file));
		}
	}
	public IEnumerator LoadSprite(string absoluteImagePath)
	{
		string      finalPath;
		WWW         localFile;
		Texture     texture;
		Sprite      sprite;

		finalPath = "file://" + absoluteImagePath;
		localFile = new WWW(finalPath);

		yield return localFile;

		Events.OnNewFile (localFile);
	}

}
