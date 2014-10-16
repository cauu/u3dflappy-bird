using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour{
	private GameState mCurrentState;

	private EStates mCurrentStateName;

	public enum EStates{
		GameStartState,
		GamePlayState,
		GameEndState
	};

	public void onStart(){
		mCurrentState = EStates.GameStartState;
	}

	public void onUpdate(){

	}

	public EStates CurrentStateName{
		get { return mCurrentStateName; }
		set { mCurrentStateName = value; }
	}

	public setGameState(GameState pCur){
		mCurrentState = pCur;
	}

	public void transite(){
		mCurrentState.transiteTo(this);
	}

}