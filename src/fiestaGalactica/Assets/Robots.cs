using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robots : MonoBehaviour {

	public Robot robot;
	public int qty = 10;
	public Transform container;

	public void Init(Texture2D[] textures, Transform camera)
	{	
		for (int a = 0; a < qty; a++) {
			Robot newRobot = Instantiate (robot);
			newRobot.transform.SetParent (container);
			newRobot.transform.localPosition = Vector3.zero;
			newRobot.Init (textures, camera, a);
		}
	}
	public void Reset()
	{
		Utils.RemoveAllChildsIn (container);
	}
}
