using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineEvent : MonoBehaviour
{
    public bool _reimportEvent;
	private IAction[] _actions;
	[HideInInspector] public bool _eventComplete;

	void Awake()
	{
		_actions = this.gameObject.GetComponents<IAction>();
	}

	void OnEnable()
	{
		foreach(IAction action in _actions)
		{
			action.Act();
		}
	}

	void Update()
	{
		CountCompleted();
	}

	void CountCompleted()
	{
		for(int index = 0; index < _actions.Length; index++)
		{
			if(!_actions[index].ActionComplete)
			{
				return;
			}
			else if (index + 1 >= _actions.Length)
			{
				print (_actions.Length);
				_eventComplete = true;
			}
		}
	}
}
