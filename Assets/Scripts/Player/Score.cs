using System;
using UnityEngine;

[Serializable]
public class Score:MonoBehaviour{
	public int m_iScore;

	public void GetSocore(int score){
		m_iScore += score;
	}

	public void OnGUI(){
		GUI.TextArea (new Rect(10,10,100,20),"Score:"+m_iScore.ToString());
	}
}


