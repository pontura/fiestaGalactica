using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour {

	public Transform container;
	public Character astronauta;
	public Character alien1;
	public Character alien2;
	public Character alien3;

	void Start () {
		Events.OnNewFile += OnNewFile;
	}
	void OnNewFile(WWW file)
	{
		string[] sinBarras = file.url.Split ("/" [0]);
		string[] sinPuntos = sinBarras[sinBarras.Length-1].Split ("." [0]);
		string fileName = sinPuntos[0];
		string[] data = fileName.Split ("_" [0]);

		int characterID = int.Parse(data[1]);
		int style1 = int.Parse(data[2]);
		int style2 = int.Parse(data[3]);
		//int style2 = int.Parse(data[3]);

		OnAddCharacter (file, characterID, style1, style2);
	}
	void OnAddCharacter(WWW file, int characterID, int style1, int style2)
	{
		Character newCharacter = null;
		characterID = 1;
		switch (characterID) {
		case 1:
			newCharacter = Instantiate (astronauta);
			newCharacter.info.type = CharacterInfo.types.ASTRONAUTA;
			break;
		case 2:
			newCharacter = Instantiate (alien1);
			newCharacter.info.type = CharacterInfo.types.ALIEN1;
			break;
		case 3:
			newCharacter = Instantiate (alien2);
			newCharacter.info.type = CharacterInfo.types.ALIEN2;
			break;
		case 4:
			newCharacter = Instantiate (alien3);
			newCharacter.info.type = CharacterInfo.types.ALIEN3;
			break;
		}

		newCharacter.transform.SetParent (container);
		newCharacter.transform.position = new Vector3 (0, 0, -5);

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
