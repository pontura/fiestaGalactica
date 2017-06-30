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
		Events.OnSpecialEffect += OnSpecialEffect;
		Events.OnLightTrip += OnLightTrip;
	}
	void Start()
	{
//#if UNITY_IPHONE
		head.transform.localEulerAngles = new Vector3(0,180,-90);
		Vector3 scale = head.transform.localScale;
		scale.y *= -1;
		head.transform.localScale = scale;
//#endif
	}
	void OnDestroy()
	{
		Events.OnSpecialEffect -= OnSpecialEffect;
	}
	void OnLightTrip(bool isOn)
	{
		if(isOn)
			states.ChangeState (StatesManager.states.LIGHTTRIP);
		else
			states.ChangeState (StatesManager.states.FLY);
	}
	void OnSpecialEffect()
	{
		states.ChangeState (StatesManager.states.SPECIAL);
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
