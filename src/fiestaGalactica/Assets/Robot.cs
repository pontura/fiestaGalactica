using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public MeshRenderer[] photos;

	public void Init(Texture2D[] textures)
	{
		int id = 0;
		foreach (MeshRenderer mr in photos) {
			mr.material.mainTexture = textures [id];
			id++;
		}
	}
}
