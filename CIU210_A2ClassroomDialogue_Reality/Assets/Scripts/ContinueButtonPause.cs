using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonPause : MonoBehaviour, IAction
{
	public bool ActionComplete
	{ 
		get { return _actionComplete; }
	}

	private bool _actionComplete;

	public void Act()
	{
		_actionComplete = false;
	}

	void Update()
	{
		if(Input.GetButtonDown("Continue"))
		{
			_actionComplete = true;
			Debug.Log ("test");
		}
	}
}