﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	public static System.Action<string> Log = delegate { };
	public static System.Action OnGameOver = delegate { };

}