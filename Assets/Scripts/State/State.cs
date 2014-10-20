using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public abstract class State : MonoBehaviour{	
	[SerializeField]
	public List<Manager> m_lstCurStateManagers;

	public List<Manager> CurStateManagers {
		get {
			return m_lstCurStateManagers;
		}
	}

	protected EStates m_eStateName;

	public EStates StateName {
		get {
			return m_eStateName;
		}
	}

	public virtual void OnInit(){
		foreach (Manager m in m_lstCurStateManagers) {
			m.OnInit();		
		}
	}

//	public abstract void OnStart();

	public virtual void OnUpdate(){
		foreach (Manager m in m_lstCurStateManagers) {
			m.OnUpdate();		
		}
	}

	public virtual void OnEnter(){
		Debug.Log ("Entering " + m_eStateName.ToString ());
		foreach (Manager m in m_lstCurStateManagers) {
			m.OnStart();		
		}
	}

	public virtual void OnExit(){
		Debug.Log ("Exiting from " + m_eStateName.ToString ());
		foreach (Manager m in m_lstCurStateManagers) {
			m.OnStop();		
		}
	}
	
	//直接跳转到pContext中GameState所对应的子类
	public void TransiteTo(FSM pStateContext){
		ExitCurrentState (pStateContext);
		EnterNewState (pStateContext);
	} 
	
	private void EnterNewState(FSM pStateContext){
		foreach (State s in pStateContext.LstAllStates) {
			if(s.StateName == pStateContext.CurStateName){
				s.OnEnter();
				pStateContext.CurState = s;
			}
		}
	}
	
	private void ExitCurrentState(FSM pStateContext){
		if (pStateContext.CurState != null) {
			pStateContext.CurState.OnExit ();
		}
	}
}