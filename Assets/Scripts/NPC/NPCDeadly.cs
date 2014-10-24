using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class NPCDeadly : NPC{
	protected override void Effected(Player player){
		//TODO: Score bonus 
		player.Die ();
	}
}