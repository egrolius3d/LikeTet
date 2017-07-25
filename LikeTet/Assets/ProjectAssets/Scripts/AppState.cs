using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LikeTet
{ 
	public  class AppState   {
    	/////////////////////////////////////////////////////////////
    	#region Variables
    	public EAppStateId mId; // переменная перечисления для установки номера состояния
        // у AppState есть два значения в словаре состояния GameState и MainMenuState()
        // mid присвоить номер соответственно к классу EAppStateId.MainMenu =  mStates[EAppStateId.Game] = new GameState();
        // mStates[EAppStateId.MainMenu] = new MainMenuState();


        #endregion
        /////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////
		#region Implementation

			public  virtual void Activate (bool reset){
			
			}
			public  virtual void Deactivate (){
				//Debug.Log ("Deactivate");
			}

        	public  virtual void Initialize(){
				// AppRoot.Instance.
           	// mId = EAppStateId.Game;

        	}
			
			public virtual void Update(){
			 	//Debug.Log ("Update from AppState");
			}
			
        	public virtual void OnGUI(){
          		//  Debug.Log("OnGUI");
        	}

        	public virtual void OnUiAction(GameObject pressedGo, object p){
           		// Debug.Log("OnUiAction");
        	}
		#endregion
		/////////////////////////////////////////////////////////////
	}
}