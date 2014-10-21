using UnityEngine;
using System;

public class Generator{

	public static GameObject GenerateGameObject(GameObject t){
		if (t == null) {
			throw new Exception("NullGameObjectException");
		}
//		Debug.Log ("Instantiate "+GameObject.Instantiate (t));
		return (GameObject)GameObject.Instantiate (t);
	}
}

