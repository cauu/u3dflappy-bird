using UnityEngine;
using System;

[Serializable]
public class PlayerManager : Manager{
	private static PlayerManager m_instance;

	public Helicopter m_player;

	public Helicopter Player {
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
		if (m_player == null) {
			throw new Exception("NullPlayerException");
		}
		IsStoped = false;
	}

	public override void OnStart(){
	}
	
	public override void OnUpdate(){
		if (!IsStoped) {
			Player.OnKeyEvents();
		}
	}

	public override void OnStop(){
		IsStoped = true;
	}
}

