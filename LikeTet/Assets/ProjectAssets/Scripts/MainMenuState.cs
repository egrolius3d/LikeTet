using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LikeTet
{
	public class MainMenuState : AppState {
		public bool exit;

		public void Update()
		{
			if (exit)
			{
			AppRoot.Instance.SetState()
			}
		}

}

}
