using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	[HideInInspector]
	public Camera c;

	public CharacterInfo info;
	public MeshRenderer head;
	public CharacterStyles styles;

	void Start()
	{
		c = FindObjectOfType<Camera> ();
	}
	public void Init()
	{
		styles.Change (info.styleHead, info.styleBody);
		head.material.mainTexture = info.texture2d;
	}
	void Update()
	{
		transform.LookAt (c.gameObject.transform);
	}

}
