using UnityEngine;
using System.Collections.Generic;

namespace LikeTet
{
    public partial class AppRoot : MonoBehaviour
    {
        ///////////////////////////////////////////////////////////////////////////
        #region Variables

        private static AppRoot mInstance;

        #endregion
        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        #region Interface

        public AppRoot()
        {
            mInstance = this;
        }

        public void Start()
        {
            InitStates();
        }

        public void Update()
        {
            UpdateStates();
        }

        public void OnGUI()
        {
            OnGUIStates();
        }

        public bool OnUiAction(GameObject pressedGo, object p)
        {
            OnUIActionStates(pressedGo, p); 
			print (pressedGo.name);
            return false;
        }


		/*public void Pause()
		{
			SetState(EAppStateId.Pause, new ScoreData() { Score =  (mStates[EAppStateId.Game] as GameState).Score });
		}
		
		public void Unpause()
		{
			SetState(EAppStateId.Game);
		}
		
		public void Restart()
		{
			AppRoot.Instance.SetState(EAppStateId.Game, true);
		}*/

        #endregion
        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        #region Implementation

        #endregion
        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        #region Properties

        public static AppRoot Instance
        {
            get
            {
                return mInstance;
            }
        }

        #endregion
        ///////////////////////////////////////////////////////////////////////////
    }

    ///////////////////////////////////////////////////////////////////////////
    #region Types
    public enum EAppStateId
    {
        MainMenu = 0,
        Game
    };
    #endregion
    ///////////////////////////////////////////////////////////////////////////

}