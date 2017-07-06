using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class PhotosManager : MonoBehaviour {

	public int totalImages;
	public string PHOTOS_URL;
	public List<string> files;
	public List<string> imagesLoaded;

	void Awake()
	{
		Events.OnSettingsLoaded += OnSettingsLoaded;
	}
	void OnSettingsLoaded()
	{
		PHOTOS_URL = Data.Instance.config.url;		
		Invoke ("Loop", 0.1f);
	}
	void Loop()
	{
		GetAllFiles ();
		Invoke ("Loop", 3);
	}
	void GetAllFiles()
	{
		//Events.Log("Getting files");
		var url = PHOTOS_URL + "load.php";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		if (www.error == null)
		{
			ParseData ( www.data);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	void ParseData(string data)
	{
		//Events.Log("Data Server Received");
		string[] imageData = data.Split ("-"[0]);
		foreach (string imageName in imageData) {
			if (imageName.Length > 1) {
				string file = (PHOTOS_URL + "photos/" + imageName);
				StartCoroutine(LoadSprite(file, imageName));
			}
		}
	}
	public IEnumerator LoadSprite(string absoluteImagePath, string imageName)
	{
	//	Events.Log("LoadSprite " + absoluteImagePath);

		if (!fileWasLoaded (imageName)) {
		
			imagesLoaded.Add (imageName);
			if (imagesLoaded.Count > totalImages) {
				Events.OnRemoveCharacters();
				imagesLoaded.RemoveAt (0);
			}

			string finalPath;
			WWW localFile;
			Texture texture;
			Sprite sprite;

			finalPath = absoluteImagePath;
			localFile = new WWW (finalPath);

			yield return localFile;

			//print (imageName + " ___  " + localFile.url);

			Events.OnNewFile (localFile);

			if (Data.Instance.build != Data.builds.DEBUG) {
				var url = PHOTOS_URL + "deleteImage.php?imageName=" + imageName;
				WWW www = new WWW (url);
			}
		} else {
			yield return null;
		}
	}
	bool fileWasLoaded(string imageName)
	{
		foreach (string oldImageName in imagesLoaded)
			if (oldImageName == imageName)
				return true;
		return false;
	}

}
