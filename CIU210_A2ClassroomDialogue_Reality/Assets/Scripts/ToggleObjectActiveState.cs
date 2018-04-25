using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectActiveState : Action, IAction
{
	public GameObject[] _objectsToToggle;
	private enum ActivateModes {TOGGLE, DISABLE, ENABLE}
	[SerializeField] private ActivateModes _currentActivateMode;

	void ChangeState()
	{
		foreach(GameObject obj in _objectsToToggle)
		{
			switch(_currentActivateMode)
			{
			case ActivateModes.TOGGLE:
				if (obj.activeSelf)
					obj.SetActive(false);
				else
					obj.SetActive(true);
				break;
			case ActivateModes.DISABLE:
				obj.SetActive(false);
				break;
			case ActivateModes.ENABLE:
				obj.SetActive(true);
				break;
			}
		}

		_actionComplete = true;
	}

	public override void Act ()
	{
		ChangeState();
	}
}
