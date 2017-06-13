using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LikeTet
{
	public class MainMenuState : AppState {

		public override void Activate (IStateData data, bool reset)
		{
			Debug.Log ("Activate main menu");

		}

		public  override void Initialize() // выполняется при запуске метод start
		{
			Debug.Log("Initialize main menu state");
			// mId = EAppStateId.Game;

		}

		public override void Update ()
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
				{
				AppRoot.Instance.SetState (EAppStateId.Game);
				}
			Debug.Log ("Update from Main Menu");
		}
	}
}
