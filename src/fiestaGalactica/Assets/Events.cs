using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	public static System.Action<string> Log = delegate { };
	public static System.Action OnGameOver = delegate { };
	public static System.Action<WWW> OnNewFile = delegate { };

	public static System.Action OnRemoveCharacters = delegate { };

	public static System.Action OnPhotoTaken= delegate { };
	public static System.Action<int, int> ChangeStyle = delegate { };
	public static System.Action CreatorReset = delegate { };
}
