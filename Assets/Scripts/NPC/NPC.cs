using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class NPC : MonoBehaviour {
	private const int EFFECT_COEFFICIENT = 2;
	public ENPCType m_eType;

	//Effect of the npc : used in a formulation with coefficient to 
	//get the effect on player score
	public int m_iEffect;
	public float m_fInitPositionX;
	public float m_fInitPositionY;
	public float m_fInitDeviation;
	public float m_fDisappearPositionX;
	public float m_fDisappearPositionY;

	//The initial force to throw a npc out
	public Vector2 m_vThrowForce;


	//Putting effect on npc instead of player can make player lighter
	public void Effected(){
		if(m_eType == ENPCType.Deadly){
			Game.GetInstance().CurStateName = EStates.GameEndState;
			Game.GetInstance().TransiteToNextState();
		}
		else if(m_eType ==ENPCType.Positive){
			//TO DO: SCORE MANAGER UPDATE
		}
		else if(m_eType == ENPCType.Negative){
			//TO DO: SCORE MANAGER UPDATE
		}
	}

	public void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			Effected();
		}
	}

}
