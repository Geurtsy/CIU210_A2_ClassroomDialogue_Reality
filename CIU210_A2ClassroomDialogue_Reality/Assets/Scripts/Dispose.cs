using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispose : Action, IAction
{
    public GameObject[] _objectToDispose;

    public override void Act()
    {
        for(int index = 0; index < _objectToDispose.Length; index++)
        {
            if(_objectToDispose[index] != null)
                Destroy(_objectToDispose[index]);
        }

        _actionComplete = true;
    }
}