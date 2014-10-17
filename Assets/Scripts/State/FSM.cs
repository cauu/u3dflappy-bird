using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public abstract class FSM{

	[SerializeField]
	public List<State> m_lstAllStates = new List<State> ();

	public List<State> LstAllStates {
		get {
			return m_lstAllStates;
		}
	}

	public State m_curState;

	protected EStates m_eCurStateName;

	public State CurState {
		set {
			m_curState = value;
		}
		get {
			return m_curState;
		}
	}

	public EStates CurStateName {
		set {
			m_eCurStateName = value;
		}
		get {
			return m_eCurStateName;
		}
	}
	public abstract void OnInit();

	public abstract void OnStart();

	public abstract void OnUpdate();

	public abstract void OnDestroy();
	
	public void TransiteToNextState(){
		if (m_curState != null) {
			m_curState.TransiteTo (this);
		}
		else{
			throw new Exception("StateDoesNotExistException");
		}
	}

}

