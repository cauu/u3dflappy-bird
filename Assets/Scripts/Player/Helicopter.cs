using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Helicopter : MonoBehaviour{
	public int m_iInitPositionX;
	public int m_iInitPositionY;
	public Vector2 m_jumpForce;
	private bool m_bIsDead;

	public void OnInit(){
		IsDead = false;
		gameObject.transform.position = new Vector3 (m_iInitPositionX, m_iInitPositionY);
		gameObject.transform.rotation = new Quaternion ();
	}


	public Vector2 JumpForce {
		set{
			m_jumpForce = value;
		}
		get {
			return m_jumpForce;
		}
	}

	public bool IsDead {
		set {
			m_bIsDead = value;
		}
		get {
			return m_bIsDead;
		}
	}

	private void Die(){
		IsDead = true;
	}

	public void OnKeyEvents(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			CopterJump();
		}
	}
	
	public void OnCollisionEnter2D(){
		Die ();
	}


	public void InitGravity(){
		gameObject.rigidbody2D.isKinematic = false;
	}

	public void RemoveGravity(){
		gameObject.rigidbody2D.isKinematic = true;
	}

	private void CopterJump(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (JumpForce);
	}
	
}
