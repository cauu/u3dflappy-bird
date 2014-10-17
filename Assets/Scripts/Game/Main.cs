using UnityEngine;
using System;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	public Game m_game;

	public void Awake(){

		//m_game = Game.GetInstance ();
		m_game.OnInit ();
	}

	public void Update(){
		m_game.OnUpdate ();
	}

	public void OnDestroy(){
		m_game.OnDestroy ();
	}
	



}


