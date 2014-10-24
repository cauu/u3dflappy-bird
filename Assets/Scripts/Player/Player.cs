using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Player : MonoBehaviour{
	public int m_iInitPositionX;
	public int m_iInitPositionY;
	public Vector2 m_jumpForce;
	private bool m_bIsDead;

	public Sprite[] m_playerSprites;
	public float m_fps;
	private SpriteRenderer m_spriteRender;
	private int m_iCurAnimIndex;

	public Score m_score;

	public void OnInit(){
		IsDead = false;
		gameObject.transform.position = new Vector3 (m_iInitPositionX, m_iInitPositionY);
		gameObject.transform.rotation = new Quaternion ();

		m_spriteRender = renderer as SpriteRenderer;
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

	public void Die(){
		IsDead = true;
	}

	public void Score(int score){
		m_score.GetSocore (score);
	}

	public void OnKeyEvents(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			CopterJump();
		}
	}

	public void OnTouchEvent(){
		if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended){
			CopterJump();
		}
	}

//	public void OnCollisionEnter2D(){
//		Die ();
//	}

	public void OnAnimate(){
		m_iCurAnimIndex = (int)(Time.timeSinceLevelLoad*m_fps);
		m_iCurAnimIndex = m_iCurAnimIndex%m_playerSprites.Length;
		m_spriteRender.sprite = m_playerSprites[m_iCurAnimIndex];
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
