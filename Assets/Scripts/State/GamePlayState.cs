using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GamePlayState : State{

	public override void OnInit(){
		m_eStateName = EStates.GamePlayState;
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