using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBackgroundColour : MonoBehaviour, IAction
{
	[SerializeField] private Color _targetColour;
	[SerializeField] private float _lerpTime;
	public bool _acting;
	private float _lerpVar;
	private Color _startColour;

	public bool ActionComplete
	{
		get{ return _actionComplete; }
	}

	private bool _actionComplete;

	public void Act()
	{
		_startColour = Camera.main.backgroundColor;
		_acting = true;
	}

	void Update()
	{
		if(_acting)
		{
			Camera.main.backgroundColor = Color.Lerp (_startColour, _targetColour, _lerpVar);
			if (_lerpVar < 1) 
			{
				_lerpVar += Time.deltaTime / _lerpTime;
			}
			else
			{
				_actionComplete = true;
			}
		}
	}
}
