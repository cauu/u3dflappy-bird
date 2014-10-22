using UnityEngine;
using System;

public class StartManager:Manager{
	public GameObject m_pressStart;
	public override void OnInit(){
		//m_pressStart.SetActive(true);
		//GameObject.Instantiate(m_pressStart);
	}

	public override void OnUpdate(){
	}

	public override void OnStart(){
		m_pressStart.SetActive(true);
	}

	public override void OnStop(){
		m_pressStart.SetActive(false);
	}
}

