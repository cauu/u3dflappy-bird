using UnityEngine;
using System;

[Serializable]
public class PlayerManager : Manager{
	private static PlayerManager m_instance;

	public Player m_player;

	public Player Player {
		get {
			return m_player;
		}
	}

	private PlayerManager(){
	}

	public static PlayerManager getInstance(){
		if (m_instance == null) {
			throw new Exception("NullPlayerManagerException");
		}
		return m_instance;
	}

	public override void OnInit(){
		Debug.Log ("Player Manager is initialized");
		if (Player == null) {
			throw new Exception("NullPlayerException");
		}
		Pause ();
		Player.OnInit ();
	}

	public override void OnStart(){
		Resume ();
	}
	
	public override void OnUpdate(){
		if (!IsStoped&&!Player.IsDead) {
			Player.OnKeyEvents();
			Player.OnAnimate();
			Player.OnTouchEvent();
		}
		if(Player.IsDead){
			Game.GetInstance().CurStateName = EStates.GameEndState;
			Game.GetInstance().TransiteToNextState();
		}
	}

	public override void OnStop(){
		//Pause ();
		//Debug.Log ("Stop rendering");
//		if(Player.IsDead){
//			Game.GetInstance().CurStateName = EStates.GameEndState;
//			Game.GetInstance().TransiteToNextState();
//		}
	}

	private void Pause(){
		IsStoped = true;
		Player.RemoveGravity ();
	}

	private void Resume(){
		IsStoped = false;
		Player.InitGravity ();
	}

}

