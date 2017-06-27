using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	public static System.Action<Vector3, Character, Character> OnConnectCharacters = delegate { };
	public static System.Action OnSettingsLoaded = delegate { };
	public static System.Action<string> Log = delegate { };
	public static System.Action OnGameOver = delegate { };
	public static System.Action<WWW> OnNewFile = delegate { };

	public static System.Action OnRemoveCharacters = delegate { };

	public static System.Action OnPhotoTaken= delegate { };
	public static System.Action<int, int> ChangeStyle = delegate { };
	public static System.Action<int> ChangeAlien = delegate { };
	public static System.Action CreatorReset = delegate { };
	public static System.Action OnSpecialEffect = delegate { };
}
