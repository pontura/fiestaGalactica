using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Creator : MonoBehaviour {

	public GameObject startingUI;
	public GameObject styles;
	public GameObject done;

	public int characterID;
	public int id;
	public int id2;
	public int totalStyles;
	public WebcamPhoto webcamPhoto;
	int screen_Shot_Count = 0;

	void Start()
	{
		startingUI.SetActive (true);
		styles.SetActive (false);
		done.SetActive (false);
		Events.OnPhotoTaken += OnPhotoTaken;
	}
	public void OnPhotoTaken()
	{
		startingUI.SetActive (false);
		styles.SetActive (true);
		StartCoroutine (Test ());
	}
	public void Create()
	{
		StartCoroutine (UploadPNG ());

		startingUI.SetActive (false);
		styles.SetActive (false);
		done.SetActive (false);

	}

	IEnumerator Test()
	{
		Debug.Log ("AA");
		WWWForm form = new WWWForm();
		WWW w = new WWW("http://127.0.0.1/runner/index.php", new byte[]{0});
		yield return w;
		if (w.error != null)
		{
			Debug.Log(w.error);
		}
		else
		{
			Debug.Log("Borra=");
			Done ();
		}
	}

	public void Next()
	{
		id++;
		if (id > totalStyles)
			id = 1;
		Events.ChangeStyle (id, id2);
	}
	public void Prev()
	{
		id--;
		if (id < 1)
			id = totalStyles;
		Events.ChangeStyle (id, id2);
	}
	public void Next2()
	{
		id2++;
		if (id2 > totalStyles)
			id2 = 1;
		Events.ChangeStyle (id, id2);
	}
	public void Prev2()
	{
		id2--;
		if (id2 < 1)
			id2 = totalStyles;
		Events.ChangeStyle (id, id2);
	}

	IEnumerator UploadPNG()
	{
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = webcamPhoto.photoTexture;

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Object.Destroy(tex);
		screen_Shot_Count++;

		string file_Name = System.DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + characterID + "_" + id + "_" + id2 + ".png";
		var fileName = Application.dataPath + "/" + file_Name;

		//File.WriteAllBytes(fileName, bytes);

		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("imageName", file_Name);
		form.AddBinaryData("fileToUpload", bytes);

		WWW w = new WWW("http://www.pontura.com/fiesta/upload.php", form);
		yield return w;

		if (w.error != null)
		{
			Debug.Log(w.error);
		}
		else
		{
			Debug.Log("Finished Uploading Screenshot");
			Done ();
		}
	}
	void Done()
	{		
		done.SetActive (true);
		startingUI.SetActive (false);
		styles.SetActive (false);
		Invoke ("DoneReady", 2);
	}
	void DoneReady()
	{
		startingUI.SetActive (true);
		done.SetActive (false);
		Events.CreatorReset ();
	}
}
