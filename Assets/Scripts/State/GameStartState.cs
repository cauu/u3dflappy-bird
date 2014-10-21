using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GameStartState : State{
	public override void OnInit(){
		base.OnInit ();
		m_eStateName = EStates.GameStartState;
	}

	public void OnKeyEvents(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			Game.GetInstance().CurStateName = EStates.GamePlayState;
			Game.GetInstance().TransiteToNextState();
		}
	}
	
	public override void OnUpdate(){
		base.OnUpdate ();
		OnKeyEvents ();
	}

	public override void OnEnter(){
		base.OnEnter ();
	}

	public override void OnExit(){
		base.OnExit ();
	}

}

