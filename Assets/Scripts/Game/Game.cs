using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Game:FSM{
	/// <summary>
	/// Singleton
	/// </summary>
	private static Game s_game = null;
	
	private Game(){
	}

	public static Game GetInstance(){
		if (s_game == null) {
			throw new Exception("NotInitialGameException");
		}
		return s_game;
	}

	public override void OnInit(){
		s_game = this;
		//The initial state of game 
		m_eCurStateName = EStates.GamePlayState;

		if (LstAllStates == null) {
			throw new Exception("NullStateListException");
		}
		InitAllStates ();
		TransiteToNextState ();
		m_curState.OnEnter ();
	}

	public override void OnStart(){
		m_curState.OnEnter ();
	}

	public override void OnUpdate(){
		m_curState.OnUpdate ();
	}

	public override void OnDestroy(){
		Application.Quit ();
	}

	private void InitAllStates(){
		foreach (State s in LstAllStates) {
			s.OnInit();
		}
	}

}