using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Creator : MonoBehaviour {

	public InputField urlField;
	public string URL = "http://192.168.0.6/fiesta/";
	public GameObject initPanel;

	public Door doorCosmonauta;
	public Door doorAliens;

	public GameObject startingUI;
	public GameObject styles;
	public GameObject stylesAliens;
	public GameObject done;


	public int id;
	public int id2;
	public int totalStyles;
	public WebcamPhoto webcamPhoto;
	int screen_Shot_Count = 0;
	public CharacterCreator characterCreator;
	public int characterSelectedID;

	void Start()
	{
		string newURL = PlayerPrefs.GetString ("url", URL);
		urlField.text = newURL;
		URL = newURL;
		initPanel.SetActive (false);
		doorAliens.gameObject.SetActive (false);
		doorCosmonauta.gameObject.SetActive (false);
		startingUI.SetActive (false);
		styles.SetActive (false);
		stylesAliens.SetActive (false);
		done.SetActive (false);
		OnSettingsLoaded ();
		Events.OnPhotoTaken += OnPhotoTaken;
		ResetDoors ();
	}
	public void SaveNewURL()
	{
		PlayerPrefs.SetString ("url", urlField.text);
	}
	void OnSettingsLoaded()
	{
		initPanel.SetActive (true);
	}

	public void CharacterSelected(int id)
	{
		this.characterSelectedID = id;
		Restart ();
	}
	void Restart()
	{
		
		initPanel.SetActive (false);

		if (characterSelectedID == 0)
			doorCosmonauta.gameObject.SetActive (true);
		else
			doorAliens.gameObject.SetActive (true);

		characterCreator.SetCharacter (characterSelectedID);
	}
	public void IntroDone()
	{
		Events.CreatorReset ();

		if (characterSelectedID == 0)
			doorCosmonauta.OpenCosmonauta ();
		else
			doorAliens.OpenAlien ();
		
		startingUI.SetActive (true);
	}
	void CloseDoors()
	{
		if (characterSelectedID == 0)
			doorCosmonauta.CloseCosmonauta ();
		else
			doorAliens.CloseAlien ();
	}

	public void OnPhotoTaken()
	{
		startingUI.SetActive (false);
		if (characterSelectedID == 0)
			styles.SetActive (true);
		else
			stylesAliens.SetActive (true);
		StartCoroutine (Test ());
	}
	public void Create()
	{
		StartCoroutine (UploadPNG ());
		startingUI.SetActive (false);
		styles.SetActive (false);
		stylesAliens.SetActive (false);
		done.SetActive (false);
		CloseDoors ();

	}

	IEnumerator Test()
	{
		Debug.Log (URL + "index.php");
		WWWForm form = new WWWForm();
		WWW w = new WWW(URL + "index.php", new byte[]{0});
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
	public void NextAlien()
	{
		characterSelectedID++;
		if (characterSelectedID > 3)
			characterSelectedID = 1;
		Events.ChangeAlien (characterSelectedID);
	}
	public void PrevAlien()
	{
		characterSelectedID--;
		if (characterSelectedID < 1)
			characterSelectedID= 3;
		Events.ChangeAlien (characterSelectedID);
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

		string file_Name = System.DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + characterSelectedID + "_" + id + "_" + id2 + ".png";
		var fileName = Application.dataPath + "/" + file_Name;

		//File.WriteAllBytes(fileName, bytes);

		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("imageName", file_Name);
		form.AddBinaryData("fileToUpload", bytes);

		WWW w = new WWW(URL + "upload.php", form);
		yield return w;

		if (w.error != null)
		{
			Debug.Log(w.error);
		}
		else
		{
			Debug.Log("Finished Uploading Screenshot to " + URL);
			Done ();
		}
		yield return new WaitForSeconds(3);
		ResetDoors ();
	}
	void Done()
	{		
		//done.SetActive (true);
		startingUI.SetActive (false);
		Invoke ("DoneReady", 2);
	}

	void DoneReady()
	{		
		done.SetActive (false);
		Restart ();
	}
	void ResetDoors()
	{
		print ("ResetDoors");
		if (characterSelectedID == 0)
			doorCosmonauta.ResetCosmonauta ();
		else
			doorAliens.ResetAliens ();
	}
}
