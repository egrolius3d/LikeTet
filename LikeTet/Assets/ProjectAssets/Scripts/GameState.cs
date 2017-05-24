using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LikeTet
{
	public class GameState : AppState {
		
		
		public void Update()
		{
			CheckUserInput ();
		}
		void CheckUserInput()
		{
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				this.transform.position += new Vector3 (-1,0,0);
			} 
			else if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{

			}
			else if (Input.GetKeyDown (KeyCode.Space)) 
			{

			}
		}
}

}