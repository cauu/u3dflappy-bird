using UnityEngine;
using System;

public class Generator{

	public static void GenerateGameObject(GameObject t){
		if (t == null) {
			throw new Exception("NullGameObjectException");
		}
		GameObject.Instantiate (t);
	}
}

