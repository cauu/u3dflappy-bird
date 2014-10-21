using System;
using UnityEngine;

[Serializable]
public abstract class Manager:MonoBehaviour{
	protected Boolean m_isStoped;

	public Boolean IsStoped {
		set{
			m_isStoped = value;
		}
		get {
			return m_isStoped;
		}
	}

	public virtual void TransitionEventHappend(){

	}

	/// <summary>
	/// Initialize when start game 
	/// </summary>
	public abstract void OnInit();

	/// <summary>
	/// Called when enter specific state
	/// </summary>
	public abstract void OnStart();

	/// <summary>
	/// Called when stay in specific state
	/// </summary>
	public abstract void OnUpdate();

	/// <summary>
	/// Called when exit from specific state
	/// </summary>
	public abstract void OnStop();

}

