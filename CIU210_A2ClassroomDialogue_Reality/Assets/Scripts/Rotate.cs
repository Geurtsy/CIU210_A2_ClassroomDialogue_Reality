using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Action, IAction
{
    [SerializeField] private GameObject _objRotating;
    [SerializeField] private Vector3 _newRotation;
    [SerializeField] private float _smoothTime;

    private float _step;

    public override void Act()
    {
        StartCoroutine(StartRotating());

        _step = 0;
    }

    IEnumerator StartRotating()
    {
        while(!_actionComplete)
        {
            _objRotating.transform.rotation = Quaternion.Lerp(_objRotating.transform.rotation, Quaternion.Euler(_newRotation.x, _newRotation.y, _newRotation.z), _step);

            if (_step < 1)
                _step += Time.deltaTime / _smoothTime;
            else
                _actionComplete = true;

            yield return null;
        }
    }
}