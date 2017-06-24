using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Config : MonoBehaviour
{
	public string url;

	void Start()
	{
		StartCoroutine (LoadData ());
	}
	IEnumerator LoadData()
	{
		string directory = "file://" + Application.dataPath + "/../" + "settings.json";
		WWW www = new WWW(directory);
		yield return www;
		LoadDataromServer( www.text);
	}
	public void LoadDataromServer(string json_data)
	{
		var Json = SimpleJSON.JSON.Parse(json_data);
		print (Json.Count);
		fillArray(Json);
	}
	private void fillArray(JSONNode content)
	{
		url = content[0]["url"];
		Events.Log (url);
		Events.OnSettingsLoaded ();
	}
}
