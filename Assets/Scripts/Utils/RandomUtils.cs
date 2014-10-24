using System;
using UnityEngine;

public class RandomUtils{

	public static float RandomFloatNumber(float range)
	{
		System.Random r = new System.Random ();
		return (float)range*((float)r.NextDouble ()*2-1);
	}

	public static int RandomSymbol(){
		System.Random r = new System.Random ();
		return r.Next (2) > 0 ? 1 : -1;
	}

	public static T RandomEnum<T>(){
		try{
			System.Array A = System.Enum.GetValues(typeof(T));
			T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
			return V;
		}
		catch(Exception e){
			Debug.Log(e);
			return default(T);
		}
	}
}

