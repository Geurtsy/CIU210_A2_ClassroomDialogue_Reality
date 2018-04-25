using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : Action, IAction
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private Transform _spawnPos;

    public override void Act()
    {
        Instantiate(_obj, _spawnPos.position, _spawnPos.rotation);

        _actionComplete = true;
    }
}