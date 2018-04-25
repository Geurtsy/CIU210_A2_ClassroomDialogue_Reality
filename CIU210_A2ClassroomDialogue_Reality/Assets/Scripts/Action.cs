using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour, IAction
{
	public bool ActionComplete
	{
		get{ return _actionComplete; }
	}

	protected bool _actionComplete;

	public abstract void Act();
}
