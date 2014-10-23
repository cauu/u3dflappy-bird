using UnityEngine;
using System;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float m_fMoveSpeed;
	public float m_fInitPositionX;
	public float m_fInitPositionY;
	public float m_fInitDeviation;
	public float m_fDisappearPositionX;

	private int m_iPosition;
	private bool m_bIsCollided;

	public bool IsCollided {
		set{
			m_bIsCollided = value;
		}
		get {
			return m_bIsCollided;
		}
	}
	
	public float MoveSpeed {
		get {
			return m_fMoveSpeed;
		}
	}

	public void InitObstacle(){
		gameObject.transform.position = new Vector3 (m_fInitPositionX, m_fInitPositionY+DecimalUtils.RandomFloatNumber(m_fInitDeviation));
		IsCollided = false;
		//test
		//rigidbody2D.AddForce(new Vector2(1000,100));
	}

	private bool IsRigidBody(){
		if (gameObject.rigidbody2D != null) {
			return true;
		}
		else{
			return false;
		}

	}

	public void OnCollisionEnter2D(){
		IsCollided = true;
	}

	private void SingleMovement(){
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x - MoveSpeed, gameObject.transform.position.y);
	}

	public void Move(){
		SingleMovement ();
	}

	public bool IsOutOfBound(){
		if (gameObject != null) {
			if(gameObject.transform.position.x <= m_fDisappearPositionX){
				return true;
			}
			else{
				return false;
			}
		}
		return false;
	}

	public void Disappear(){
		Destroy (gameObject);
	}
}
