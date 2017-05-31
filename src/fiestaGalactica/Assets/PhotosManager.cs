using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotosManager : MonoBehaviour {

	public List<Texture2D> photos;

	string pathPrefix = @"file://";
	string pathImageAssets = @"C:\fiestaGalactica\";
	string pathSmall = @"images\";
	string filename = @"a.png";

	void Start()
	{
		LoadImages ();
	}
	private void LoadImages()
	{
		Events.Log ("LoadImages");
		string fullFilename = pathPrefix + pathImageAssets + pathSmall + filename;
		StartCoroutine( StartLoading(fullFilename));
	}

	IEnumerator StartLoading(string fullFilename)
	{
		Texture2D tex;
		tex = new Texture2D(256, 256, TextureFormat.DXT1, false);
		WWW www = new WWW(fullFilename);
		yield return www;
		www.LoadImageIntoTexture(tex);
		photos.Add (tex);
	}

}
