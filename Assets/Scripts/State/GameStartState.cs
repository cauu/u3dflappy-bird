using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GameStartState : State{
	public override void OnInit(){
		m_eStateName = EStates.GameEndState;
	}
	
	public override void OnUpdate(){

	}

	public override void OnEnter(){
		Debug.Log ("Entering " + m_eStateName.ToString ());
	}

	public override void OnExit(){

	}

}

