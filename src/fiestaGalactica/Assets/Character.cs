using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public CharacterInfo info;
	public SpriteRenderer head;
	public Camera c;

	void Start()
	{
		c = FindObjectOfType<Camera> ();
	}
	public void Init()
	{
		head.sprite = info.sprite;
	}
	void Update()
	{
		transform.LookAt (c.gameObject.transform);
	}

}
