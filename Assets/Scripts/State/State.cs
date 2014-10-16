using UnityEngine;
using System.Collections;
using System.Reflection;

public abstract class State{	

	public abstract void onStart();

	public abstract void onUpdate();

	//直接跳转到pContext中GameState所对应的子类
	public void transiteTo(Game pContext){
		
	} 
}