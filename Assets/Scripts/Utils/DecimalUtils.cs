using System;

public class DecimalUtils{

	public static float RandomFloatNumber(float range)
	{
		System.Random r = new System.Random ();
		return (float)range*((float)r.NextDouble ()*2-1);
	}
	
}

