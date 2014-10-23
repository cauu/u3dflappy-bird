using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GameStartState : State{
	public override void OnInit(){
		base.OnInit ();
		m_eStateName = EStates.GameStartState;
	}

	public override void OnKeyEvent(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			Game.GetInstance().CurStateName = EStates.GamePlayState;
			Game.GetInstance().TransiteToNextState();
		}
	}

	public override void OnTouchEvent(){
		if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended){
			Game.GetInstance().CurStateName = EStates.GamePlayState;
			Game.GetInstance().TransiteToNextState();
		}
	}
	
	public override void OnUpdate(){
		base.OnUpdate ();
		OnKeyEvent ();
		OnTouchEvent();
	}

	/// <summary>
	/// Initialize all manager in gamestartstate
	/// </summary>
	public override void OnEnter(){
		base.OnEnter ();
	}

	public override void OnExit(){
		base.OnExit ();
	}

}

