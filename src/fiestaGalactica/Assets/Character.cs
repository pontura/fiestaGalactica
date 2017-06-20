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
	private Animator anim;

	void Start()
	{
		states = GetComponent<StatesManager> ();
		anim = GetComponent<Animator> ();
		c = FindObjectOfType<Camera> ();
		anim.Play ("Launch");
	}
	public void Init()
	{
		styles.Change (info.styleHead, info.styleBody);
		head.material.mainTexture = info.texture2d;
	}
	void Updatess()
	{
		if(lookAtCamera)
			transform.LookAt (c.gameObject.transform);
	}

}
