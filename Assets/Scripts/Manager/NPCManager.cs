using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : Manager {
	public List<NPC> m_lstNPCPrefabs;
	private List<GameObject> m_lstNPCInstance;

	public float m_fNPCStartTime;
	public float m_fNPCGenerationGap;

	public override void OnInit(){
		Debug.Log("Initialize NPC Manager.");
		if (m_lstNPCPrefabs == null) {
			throw new Exception("NullPrefabException");
		}
		m_lstNPCInstance = new List<GameObject> ();
	}

	public override void OnStart(){
		InvokeRepeating ("GenerateNPC", m_fNPCStartTime, m_fNPCGenerationGap);
	}

	public override void OnUpdate(){
		MoveAllNPCs ();
		DestroyOutOfBoundNPCs ();
	}

	public override void OnStop(){
		CancelInvoke ();
		m_lstNPCInstance.Clear ();
	}

	private void MoveAllNPCs(){
		foreach (GameObject o in m_lstNPCInstance) {
			o.GetComponent<NPC>().Move();
		}
	}

	private void DestroyOutOfBoundNPCs(){
		//Cannot remove objects in the loop
		for (int i = 0; i<=m_lstNPCInstance.Count-1; i++) {
			if(m_lstNPCInstance[i].GetComponent<NPC>().DestoryOutOfBound()||m_lstNPCInstance[i]==null){
				m_lstNPCInstance.RemoveAt(i);
			}
		}
	}

	private void GenerateNPC(){
		//TODO: type code is randomly generated.
		ENPCType typeCode = RandomUtils.RandomEnum<ENPCType> ();

		foreach (NPC n in m_lstNPCPrefabs) {
			if(n.m_eType == typeCode){
				if(n.gameObject == null)
					throw new Exception("NullAttachedGameObjectException");
				GameObject tempNPC = Generator.GenerateGameObject(n.gameObject);
				tempNPC.GetComponent<NPC>().Appear();
				m_lstNPCInstance.Add(tempNPC);
				break;
			}
		}
	}
}
