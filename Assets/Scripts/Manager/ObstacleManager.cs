using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObstacleManager : Manager
{
	private static ObstacleManager m_instance;

	public GameObject m_obstacle;
	private Obstacle ob;
	private List<GameObject> m_lstObstacles;
	public float m_fObstacleStartTime;
	public float m_fObstacleGenerationGap;

		
	private ObstacleManager(){
	}
	
	public static ObstacleManager getInstance(){
		if (m_instance == null) {
			throw new Exception("NullObstacleManagerException");
		}
		return m_instance;
	}
	
	public override void OnInit(){
		Debug.Log ("Obstacle manager is initialized");
		if (m_obstacle == null) {
			throw new Exception("NullObstacleException");
		}
		m_lstObstacles = new List<GameObject> ();
		IsStoped = false;
	}
	
	public override void OnStart(){
//		Debug.Log ("manager is " + m_lstObstacles);

		//GenerateObstacles ();
		InvokeRepeating ("GenerateObstacles", m_fObstacleStartTime,m_fObstacleGenerationGap);
	}
	
	public override void OnUpdate(){
		if (!IsStoped) {
			MoveObstacles ();
			DestroyOutOfBoundObstacles();
			StopGenerationWhenCollision();
		}
		//ob.Move ();
	}
	
	public override void OnStop(){
		IsStoped = true;
		CancelInvoke ();
	}

//	private void StartGenerateObstacles(){
//		m_lstObstacles.Add(Generator.GenerateGameObject (m_obstacle));
//		ob = m_lstObstacles[0].GetComponent<Obstacle> ();
//		ob.InitObstacle ();
//	}

	private void GenerateObstacles(){
		GameObject newObstacle = Generator.GenerateGameObject (m_obstacle);
		newObstacle.GetComponent<Obstacle> ().InitObstacle ();
		m_lstObstacles.Add(newObstacle);
	}

	private void StopGenerationWhenCollision(){
		foreach (GameObject o in m_lstObstacles) {
			if (o.GetComponent<Obstacle> ().IsCollided) {
					IsStoped = true;
					CancelInvoke ();
					break;
			}
		}
	}

	private void DestroyOutOfBoundObstacles(){
		int index = -1;
		foreach (GameObject o in m_lstObstacles){
			if(o.GetComponent<Obstacle>().IsOutOfBound()){
				index = m_lstObstacles.IndexOf(o);
				o.GetComponent<Obstacle>().Disappear();
				break;
			}
		}
		if (index != -1) {
			m_lstObstacles.RemoveAt (index);
			index=-1;
		}
	}

	private void MoveObstacles(){
		foreach (GameObject o in m_lstObstacles) {
			o.GetComponent<Obstacle>().Move();
		}

	}
}


