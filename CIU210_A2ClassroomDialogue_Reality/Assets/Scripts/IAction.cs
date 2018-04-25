using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IAction
{
	bool ActionComplete{ get; }

	void Act();
}
