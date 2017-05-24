using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LikeTet
{ 
	public class AppState: MonoBehaviour   {
    /////////////////////////////////////////////////////////////
    #region Variables
    public EAppStateId mId; // переменная перечисления для установки номера состояния
        // у AppState есть два значения в словаре состояния GameState и MainMenuState()
        // mid присвоить номер соответственно к классу EAppStateId.MainMenu =  mStates[EAppStateId.Game] = new GameState();
        // mStates[EAppStateId.MainMenu] = new MainMenuState();


        #endregion
        /////////////////////////////////////////////////////////////


        public void Activate (IStateData data, bool reset)
	{
		Debug.Log ("Activate");
	}
	public void Deactivate ()
	{
		Debug.Log ("Deactivate");
	}

        public void Initialize() // выполняется при запуске метод start
        {
            Debug.Log("Initialize");
           // mId = EAppStateId.Game;

        }

        public void Update()
        {
            Debug.Log("Update"); /// выполняется каждую секунду Update от AppRoot
        }

        public void OnGUI()
        {
            Debug.Log("OnGUI");
        }
        public void OnUiAction(GameObject pressedGo, object p)
        {
            Debug.Log("OnUiAction");
        }


}
}