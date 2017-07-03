using UnityEngine;
using System.Collections.Generic;

namespace LikeTet
{
    public partial class AppRoot : MonoBehaviour
    {
        ///////////////////////////////////////////////////////////////////////////
        #region Variables

        private Dictionary<EAppStateId, AppState> mStates = new Dictionary<EAppStateId, AppState>();
        private AppState mCurState;

        #endregion
        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        #region Interface

        public AppState GetState(EAppStateId id)
        {
            AppState state;

            if (mStates.TryGetValue(id, out state))
            {
                return state;
            }

            return null;
        }

        public void SetState(EAppStateId id)
        {
            SetState(id, false, null);
        }

        public void SetState(EAppStateId id, bool resetState)
        {
            SetState(id, resetState, null);
        }

        public void SetState(EAppStateId id, IStateData data)
        {
            SetState(id, false, data);
        }

        public void SetState(EAppStateId id, bool resetState, IStateData data)
        {
            if (mCurState == null)
            {
                AppState newState;

                if (!mStates.ContainsKey(id))
                {
                    Debug.LogWarning("Error! Cannot find state: " + id);
                    newState = mStates[EAppStateId.MainMenu];
                }
                else
                {

                    newState = mStates[id];
                }

                mCurState = newState;
                mCurState.Activate(data, resetState);
                return;
            }
            Debug.Log(id + " " + mCurState.mId);
            if (mCurState.mId != id)
            {
                AppState newState;

                if (!mStates.ContainsKey(id))
                {
                    Debug.LogWarning("Error! Cannot find state: " + id);
                    newState = mStates[EAppStateId.MainMenu];
                    newState = mStates[EAppStateId.Game];
                }
                else
                {
                    newState = mStates[id];
                }

                if (newState != mCurState || resetState)
                {
                    mCurState.Deactivate();
                    mCurState = newState;
                    mCurState.Activate(data, resetState);
                }
                else
                {
                    Debug.Log("Error! Cannot set new state: newState = mCurState!");
                }
            }
            else
            {
                Debug.Log("Error trying to set the SAME state!");
            }

            //Debug.Log(mCurState);
        }

        #endregion
        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        #region Implementation

        private void InitStates()
        {
            Debug.Log("AppRoot::InitStates called");

            mStates[EAppStateId.Game] = new GameState();
            mStates[EAppStateId.MainMenu] = new MainMenuState();
            // mStates[EAppStateId.Pause] = new PauseState();
            mStates[EAppStateId.GameOver] = new GameOverState();

            foreach (KeyValuePair<EAppStateId, AppState> statePair in mStates)
            {
                statePair.Value.Initialize();
                Debug.Log("Init+" + statePair.Value);
            }

			SetState(EAppStateId.MainMenu);
            //mCurState.Initialize();
        }

        private void UpdateStates()
        {
            if (mCurState != null)
            {
                mCurState.Update(); // alternative  for Update
            }
        }

        /*private void StartStates()
        {
            if (mCurState != null)
            {
                mCurState.Initialize();
            }
        }*/

        private void OnGUIStates()
        {
            if (mCurState != null)
            {
                mCurState.OnGUI();
            }
        }

        private void OnUIActionStates(GameObject pressedGo, object p)
        {
            if (mCurState != null)
            {
                mCurState.OnUiAction(pressedGo, p);
            }
        }

        #endregion
        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        #region Properties

        public AppState State
        {
            get { return mCurState; }
        }

        public EAppStateId StateId
        {
            get { return mCurState.mId; }
        }

        #endregion
        ///////////////////////////////////////////////////////////////////////////
    }

}