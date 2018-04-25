using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEventCompletion : MonoBehaviour, IAction
{
	[SerializeField] private float _pauseLength;
	private float _currentTime;
	private bool _acting;

	public bool ActionComplete
	{
		get{ return _actionComplete; }
	}

	private bool _actionComplete;

	public void Act()
	{
		_acting = true;
	}

	void Update()
	{
		if(_acting)
		{
			_currentTime += Time.deltaTime;

			if (_currentTime > _pauseLength)
				_actionComplete = true;
		}
	}
}
