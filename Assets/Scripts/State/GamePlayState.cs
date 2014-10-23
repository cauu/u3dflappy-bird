using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GamePlayState : State{

	public override void OnInit(){
		base.OnInit ();
		m_eStateName = EStates.GamePlayState;
	}

	public override void OnUpdate(){
		base.OnUpdate ();
	}

	public override void OnEnter(){
		//Can use memento pattern to restore player and obstacle status
		base.OnInit ();
		base.OnEnter ();
	}	

	public override void OnKeyEvent(){
	}

	public override void OnTouchEvent(){
	}

	public override void OnExit(){
		base.OnExit ();
	}
}