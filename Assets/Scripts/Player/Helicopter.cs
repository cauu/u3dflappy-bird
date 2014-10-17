using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Helicopter : MonoBehaviour{
	public Vector2 m_jumpForce;

	public Vector2 JumpForce {
		set{
			m_jumpForce = value;
		}
		get {
			return m_jumpForce;
		}
	}

	public void OnKeyEvents(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			copterJump();
		}
	}

	private void copterJump(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (JumpForce);
	}
	
}
