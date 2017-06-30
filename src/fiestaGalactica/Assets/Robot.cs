﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public MeshRenderer[] photos;
	bool started;
	float randomX;
	private Transform target;
	Texture2D[] textures;
	int id = 0;
	void Start()
	{		
		gameObject.SetActive (false);
	}
	void OnDestroy()
	{
		started = false;
		photos = null;
	}
	int robotID;
	public void Init(Texture2D[] _textures, Transform camera, int robotID)
	{	
		textures = _textures;
		this.robotID = robotID;
		target = camera;

		id = robotID*3;
		Invoke("StartAnim", robotID*5);	
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
	void StartAnim()
	{
		gameObject.SetActive (true);
		started = true;
		if (robotID == 1)
			randomX = 0.3f;
		else if (robotID == 2)
			randomX = -0.3f;
		else
			randomX = 0;
		//randomX = (float)(Random.Range (0, 100)-50)/100;
	}
	void Update()
	{
		transform.LookAt (target);
		if (!started)
			return;
		Vector3 pos = transform.position;
		pos.x += randomX*Time.deltaTime;
		transform.position = pos;
	}
}
