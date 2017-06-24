using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public Animation buttonAnim;
	public Animation myAnim;

	public void ResetCosmonauta()
	{
		buttonAnim.Play ("closeButtonDoor");
	}
	public void ResetAliens()
	{
		buttonAnim.Play ("closeButtonDoor");
	}
	public void OpenCosmonauta()
	{
		myAnim.Play ("OpenCosmonautaDoors");
		buttonAnim.Play ("start");
	}
	public void OpenAlien()
	{
		myAnim.Play ("OpenAliensDoors");
		buttonAnim.Play ("start");
	}
	public void CloseCosmonauta()
	{
		myAnim.Play ("CloseCosmonautaDoors");
	}
	public void CloseAlien()
	{
		myAnim.Play ("CloseAlienDoors");
	}
}
