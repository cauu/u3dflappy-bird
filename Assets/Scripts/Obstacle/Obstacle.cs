using UnityEngine;
using System;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float m_fMoveSpeed;
	public float m_fInitPositionX;
	public float m_fInitPositionY;
	private int m_iPosition;


	public float MoveSpeed {
		get {
			return m_fMoveSpeed;
		}
	}

	public void InitObstacle(){
		this.transform.position = new Vector3 (m_fInitPositionX, m_fInitPositionY);
	}

	private bool IsRigidBody(){
		if (this.rigidbody2D != null) {
			return true;
		}
		else{
			return false;
		}

	}

	private void SingleMovement(){
		this.transform.position = new Vector3 (this.transform.position.x - MoveSpeed, this.transform.position.y);
	}

	public void Move(){
		SingleMovement();
	}
}
