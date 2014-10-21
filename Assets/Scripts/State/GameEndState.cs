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
		if (Input.GetKeyUp (KeyCode.Space)) {
			Game.GetInstance().CurStateName = EStates.GameStartState;
			Game.GetInstance().TransiteToNextState();
		}

	}

	public override void OnEnter(){
		base.OnEnter ();
	}
	
	public override void OnExit(){
		base.OnExit ();
	}
}