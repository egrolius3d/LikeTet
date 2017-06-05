using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour {

	public float fallSpeed=1;
	float fall=0;

	
	// Update is called once per frame
	void Update () {
		CheckUserInput ();
	}

	void CheckUserInput()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.transform.position += new Vector3 (-1,0,0);

		} 
		else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			this.transform.position += new Vector3 (1,0,0);
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)|| Time.time-fall>=fallSpeed) 
		{
			this.transform.position += new Vector3 (0,-1,0);
			fall = Time.time;
		}
		else if (Input.GetKeyDown (KeyCode.Space)) 
		{
			this.transform.Rotate (0,0,90);
		}
	}
	public static bool isInsideGrid ()
	{
		return true;
	}
}
