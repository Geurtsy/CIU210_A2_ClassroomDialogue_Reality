using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSprite : MonoBehaviour, IAction
{
	[SerializeField] private SpriteRenderer _sprChanging;
	[SerializeField] private Sprite _newSpr;

	public bool ActionComplete
	{
		get{ return _actionComplete; }
	}

	private bool _actionComplete;

	public void Act()
	{
		_sprChanging.sprite = _newSpr;
		_actionComplete = true;
	}
}
