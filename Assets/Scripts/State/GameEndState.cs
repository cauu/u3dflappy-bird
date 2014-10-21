using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GameEndState : State{
	public override void OnInit(){
		base.OnInit ();
		m_eStateName = EStates.GameEndState;
	}

	public override void OnUpdate(){
		base.OnUpdate ();

	}

	public override void OnEnter(){
		base.OnEnter ();
	}
	
	public override void OnExit(){
		base.OnExit ();
	}
}