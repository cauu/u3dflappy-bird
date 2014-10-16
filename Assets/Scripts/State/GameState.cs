using UnityEngine;
using System.Collections;

public abstract class GameState{	

	public abstract void onStart();

	public abstract void onUpdate();

	public void transiteTo(Game pContext){
		if(pContext)

	} 
}