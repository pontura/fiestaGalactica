using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour {

	public List<Texture2D> all;
	public Transform propulsorAliens;
	public Transform propulsorCosmonautas;

	public Transform container;
	public Character astronauta;
	public Character alien1;
	public Character alien2;
	public Character alien3;
	public Character alien4;

	public CharactersConnection connectionAsset;

	[HideInInspector]
	public List<Character> charactersToDelete;
	void Start () {
		Events.OnNewFile += OnNewFile;
		Events.OnRemoveCharacters += OnRemoveCharacters;
		Events.OnConnectCharacters += OnConnectCharacters;
		Events.OnLightTrip += OnLightTrip;
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
			OnAddCharacter (null, 0, Random.Range(1,4), Random.Range(1,4), "20170621013837");
		if(Input.GetKeyDown(KeyCode.A))
			OnAddCharacter (null, Random.Range(1,4), 1, 1, "20170621013837");
	}
	void OnNewFile(WWW file)
	{
		string[] sinBarras = file.url.Split ("/" [0]);
		string imageName = sinBarras [sinBarras.Length - 1];
		string[] sinPuntos = imageName.Split ("." [0]);
		string fileName = sinPuntos[0];
		string[] data = fileName.Split ("_" [0]);

		int characterID = int.Parse(data[1]);
		int style1 = int.Parse(data[2]);
		int style2 = int.Parse(data[3]);
		//int style2 = int.Parse(data[3]);

		OnAddCharacter (file, characterID, style1, style2, imageName);
	}
	void OnLightTrip(bool isOn)
	{
		if (!isOn)
			DeleteRandomCharacters ();
	}
	void OnRemoveCharacters()
	{
		Invoke ("UpdateCharacters", 1);
	}
	void UpdateCharacters()
	{
		Character[] characters = container.GetComponentsInChildren<Character> ();

		foreach (Character character in characters) {
			if (!IsCharacterStillOnList (character.url)) {
				charactersToDelete.Add (character);
			}
		}
		for (int a = 0; a < charactersToDelete.Count; a++) {
			DestroyImmediate (charactersToDelete [a].gameObject);
		}
		charactersToDelete.Clear ();
		characters = null;
	}
	void DeleteRandomCharacters()
	{
		Character[] characters = container.GetComponentsInChildren<Character> ();
		if (characters.Length > 0) {
			charactersToDelete.Clear ();
			for (int a=0; a<characters.Length; a++) {
				if (Random.Range(0,100)<50) {
					charactersToDelete.Add (characters[a]);
				}
			}
			for (int a = 0; a < charactersToDelete.Count; a++) {
				DestroyImmediate (charactersToDelete [a].gameObject);
			}
			charactersToDelete.Clear ();
			characters = null;
		}
	}
	bool IsCharacterStillOnList(string userName)
	{
		foreach (string imageName in Data.Instance.photosManager.imagesLoaded) {
			if (userName == imageName) {
				return true;
			}					
		}
		return false;
	}
	void OnAddCharacter(WWW file, int characterID, int style1, int style2, string imageName)
	{
		Character newCharacter = null;

		switch (characterID) {
		case 0:
			newCharacter = Instantiate (astronauta);
			newCharacter.info.type = CharacterInfo.types.ASTRONAUTA;
			break;
		case 1:
			newCharacter = Instantiate (alien1);
			newCharacter.info.type = CharacterInfo.types.ALIEN1;
			break;
		case 2:
			newCharacter = Instantiate (alien2);
			newCharacter.info.type = CharacterInfo.types.ALIEN2;
			break;
		case 3:
			newCharacter = Instantiate (alien3);
			newCharacter.info.type = CharacterInfo.types.ALIEN3;
			break;
		case 4:
			newCharacter = Instantiate (alien4);
			newCharacter.info.type = CharacterInfo.types.ALIEN4;
			break;
		}
		newCharacter.url = imageName;
		newCharacter.transform.SetParent (container);

		Vector3 pos;
		if(newCharacter.info.type == CharacterInfo.types.ASTRONAUTA)
			pos = propulsorCosmonautas.transform.position;
		else
			pos = propulsorAliens.transform.position;
		
		pos.z = -5;
		newCharacter.transform.position = pos;

		Texture2D texture = null;
		if (file != null) {
			texture = file.texture;
			all.Add (texture);
			if (all.Count >= Data.Instance.photosManager.totalImages) {
				GameObject.DestroyImmediate (all [0]);
				all.RemoveAt (0);
			}
		}

		//Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

		if (newCharacter != null) {
			newCharacter.info.styleHead = style1;
			newCharacter.info.styleBody = style2;
			newCharacter.info.texture2d = texture;

			newCharacter.Init ();
			newCharacter.states.ChangeState (StatesManager.states.LAUNCH);
		} else {
			Debug.Log ("No existe el character");
		}
	}
	float lastTimeConnected;
	void OnConnectCharacters(Vector3 pos, Character ch1, Character ch2)
	{
		if (Time.time - 0.5f < lastTimeConnected)
			return;

		if (ch1.states.state == StatesManager.states.CONNECT || ch2.states.state == StatesManager.states.CONNECT)
			return;

		lastTimeConnected = Time.time;

		CharactersConnection charactersConnection = Instantiate (connectionAsset);
		charactersConnection.transform.localPosition = pos;

		charactersConnection.Init (ch1, ch2);

		ch1.states.ChangeState (StatesManager.states.CONNECT);
		ch2.states.ChangeState (StatesManager.states.CONNECT);
	}
}
