using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class ObstacleManager : Manager
{
	private static ObstacleManager m_instance;

	public GameObject m_obstacle;
	private Obstacle ob;
		
	private ObstacleManager(){
	}
	
	public static ObstacleManager getInstance(){
		if (m_instance == null) {
			throw new Exception("NullObstacleManagerException");
		}
		return m_instance;
	}
	
	public override void OnInit(){
		if (m_obstacle == null) {
			throw new Exception("NullObstacleException");
		}
		IsStoped = false;
	}
	
	public override void OnStart(){
		Generator.GenerateGameObject (m_obstacle);
		ob = m_obstacle.GetComponent<Obstacle> ();
		ob.InitObstacle ();

	}
	
	public override void OnUpdate(){
		ob.Move ();
	}
	
	public override void OnStop(){
		IsStoped = true;
	}
}


