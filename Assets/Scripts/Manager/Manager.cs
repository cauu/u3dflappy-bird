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

	public abstract void OnInit();

	public abstract void OnStart();

	public abstract void OnUpdate();

	public abstract void OnStop();

}

