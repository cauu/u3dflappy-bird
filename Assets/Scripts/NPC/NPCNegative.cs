using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class NPCNegative : NPC{
	protected override void Effected(Player player){
		//TODO: Score bonus can also add some physical effect when collision happens
		player.Score(-1);
	}
}