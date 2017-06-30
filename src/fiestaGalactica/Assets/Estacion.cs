using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion : MonoBehaviour {

	public MeshRenderer[] photos;
	public GameObject asset;
	public int _x = 38;
	float speed = 10;
	Texture2D[] textures;
	int id = 0;

	public void Init(Texture2D[] _textures, Transform camera)
	{	
		this.textures = _textures;
		asset.transform.localPosition = new Vector3 (_x, 0, 0);
		asset.SetActive (true);

		SetPhotos ();
	}
	void SetPhotos()
	{		
		if (textures.Length == 0)
			return;
		foreach (MeshRenderer mr in photos) {
			if (textures.Length <= id)
				id = 0;
			mr.material.mainTexture = textures [id];
			id++;
		}
	}
	public void Reset()
	{
		asset.SetActive (false);
		//foreach (Texture2D t2d in textures)
			//GameObject.DestroyImmediate (t2d);
		this.textures = null;
	}
	bool up = false;
	bool front = false;
	void Update()
	{
		Vector3 pos = asset.transform.localPosition;
		pos.x -= Time.deltaTime * speed;
		if (pos.x < -_x) {
			SetPhotos ();
			pos.x = _x;
		}
		if (up) 
			pos.y += Time.deltaTime * speed/6;
		else
			pos.y -= Time.deltaTime * speed/6;

		if (pos.y > 3)
			up = false;
		else if (pos.y < -3)
			up = true;

		if (front) 
			pos.z += Time.deltaTime * speed/20;
		else
			pos.z -= Time.deltaTime * speed/20;

		if (pos.z > 20)
			front = false;
		else if (pos.z < -1)
			front = true;
		
		asset.transform.localPosition = pos;
	}
}
