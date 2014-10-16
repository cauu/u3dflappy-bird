using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour{
	private State mCurrentState;

	private EStates mCurrentStateName;

	public enum EStates{
		GameStartState,
		GamePlayState,
		GameEndState
	};

	public void onStart(){
		mCurrentStateName = EStates.GameStartState;
	}

	public void onUpdate(){

	}

	public EStates CurrentStateName{
		get { return mCurrentStateName; }
		set { mCurrentStateName = value; }
	}

	public void setGameState(State pCur){
		mCurrentState = pCur;
	}

	public void transite(){
		mCurrentState.transiteTo(this);
	}

}