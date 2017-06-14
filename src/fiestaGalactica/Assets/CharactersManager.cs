using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour {

	public Transform propulsorAliens;
	public Transform propulsorCosmonautas;

	public Transform container;
	public Character astronauta;
	public Character alien1;
	public Character alien2;
	public Character alien3;

	[HideInInspector]
	public List<Character> charactersToDelete;
	void Start () {
		Events.OnNewFile += OnNewFile;
		Events.OnRemoveCharacters += OnRemoveCharacters;
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
			Destroy (charactersToDelete [a].gameObject);
		}
		charactersToDelete.Clear ();
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
		print ("characterID: " + characterID);
		Character newCharacter = null;

		switch (characterID) {
		case 1:
			newCharacter = Instantiate (astronauta);
			newCharacter.info.type = CharacterInfo.types.ASTRONAUTA;
			break;
		case 2:
			newCharacter = Instantiate (astronauta);
			newCharacter.info.type = CharacterInfo.types.ALIEN1;
			break;
		case 3:
			newCharacter = Instantiate (astronauta);
			newCharacter.info.type = CharacterInfo.types.ALIEN2;
			break;
		case 4:
			newCharacter = Instantiate (astronauta);
			newCharacter.info.type = CharacterInfo.types.ALIEN3;
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

		Texture2D texture = file.texture;
		//Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

		if (newCharacter != null) {
			newCharacter.info.styleHead = style1;
			newCharacter.info.styleBody = style2;
			newCharacter.info.texture2d = texture;

			newCharacter.Init ();
		} else {
			Debug.Log ("No existe el character");
		}
	}
}
