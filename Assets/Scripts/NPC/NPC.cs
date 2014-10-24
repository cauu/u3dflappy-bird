using UnityEngine;
using System;
using System.Collections;

[Serializable]
public abstract class NPC : MonoBehaviour {
	public int EFFECT_COEFFICIENT ;
	public ENPCType m_eType;

	//Effect of the npc : used in a formulation with coefficient to 
	//get the effect on player score
	public float m_fMoveSpeed;
	public int m_iEffect;
	public float m_fInitPositionX;
	public float m_fInitPositionY;
	public Vector2 m_fDisappearTopLeft;
	public Vector2 m_fDisappearDownRight;

	//Three random number to control the position of npc      
	public float m_fInitPosDeviation;
	public float m_fInitForceDeviation;
	//The initial force to throw a npc out
	public Vector2 m_enterForce;

	public void Move(){
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x - m_fMoveSpeed,gameObject.transform.position.y);
		gameObject.transform.rotation = new Quaternion ();
	}

	//Randomly appear some caonima
	public void Appear(){
		int direction = RandomUtils.RandomSymbol ();
		float posDeviation = RandomUtils.RandomFloatNumber (m_fInitPosDeviation);
		float forceDeviation = RandomUtils.RandomFloatNumber (m_fInitForceDeviation);

		this.transform.position = new Vector3 (m_fInitPositionX+posDeviation, m_fInitPositionY*direction);
		rigidbody2D.AddForce (new Vector2(m_enterForce.x*direction,direction*(m_enterForce.y+forceDeviation)));
	}

	public void Disappear(){
		if (gameObject == null) {
			throw new Exception ("NullAttachedGameObjectException");
		}
		Destroy(gameObject);
	}

	public bool DestoryOutOfBound(){
		if (gameObject == null) {
			throw new Exception ("NullAttachedGameObjectException");
		}
		if (OutOfBound(gameObject.transform)) {
			Disappear();
			return true;
		}
		return false;
	}


	private bool OutOfBound(Transform t){
		return (t.position.x < m_fDisappearTopLeft.x) || (t.position.x > m_fDisappearDownRight.x) || (t.position.y > m_fDisappearTopLeft.y)
						|| (t.position.y < m_fDisappearDownRight.y);
	}


	//Putting effect on npc instead of player can make player lighter
	protected abstract void Effected (Player player);

	public void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			Effected(coll.gameObject.GetComponent<Player>());
		}
	}

}
