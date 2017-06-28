using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public MeshRenderer[] photos;
	bool started;
	float randomX;
	private Transform target;

	void Start()
	{		
		gameObject.SetActive (false);
	}
	void OnDestroy()
	{
		started = false;
		photos = null;
	}
	public void Init(Texture2D[] textures, Transform camera)
	{	
		
		target = camera;
		int id = 0;
		foreach (MeshRenderer mr in photos) {
			mr.material.mainTexture = textures [id];
			id++;
		}
		float rand = (float)Random.Range (0, 100) / 10;
		Invoke("StartAnim", rand);	
	}
	void StartAnim()
	{
		gameObject.SetActive (true);
		started = true;
		randomX = (float)(Random.Range (0, 100)-50)/100;
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
