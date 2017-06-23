using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	[HideInInspector]
	public Camera c;
	public bool lookAtCamera = true;
	public CharacterInfo info;
	public MeshRenderer head;
	public CharacterStyles styles;
	public StatesManager states;
	public string url;

	void Awake()
	{
		states = GetComponent<StatesManager> ();
		c = FindObjectOfType<Camera> ();
	}
	public void Init()
	{
		
		if(info.type == CharacterInfo.types.ASTRONAUTA)
			styles.Change (info.styleHead, info.styleBody);
		
		head.material.mainTexture = info.texture2d;
	}
	void Updatess()
	{
		if(lookAtCamera)
			transform.LookAt (c.gameObject.transform);
	}

}
