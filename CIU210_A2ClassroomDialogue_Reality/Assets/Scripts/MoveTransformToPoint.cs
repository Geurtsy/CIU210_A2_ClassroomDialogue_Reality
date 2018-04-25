using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformToPoint : MonoBehaviour, IAction
{
	[SerializeField] private Transform _movingTransform;
	[SerializeField] private Transform _target;
	[SerializeField] private float _speed;
	[SerializeField] private bool _smooth;

	[SerializeField] private float _accuracyMeasure;

	public bool ActionComplete
	{
		get{ return _actionComplete; }
	}

	private bool _actionComplete;

	public void Act()
	{
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		while((_movingTransform.position - _target.position).magnitude > _accuracyMeasure)
		{
			Vector3 directionToTarget = (_target.position - _movingTransform.position).normalized;
			_movingTransform.position += directionToTarget * _speed * Time.deltaTime;
			yield return null;
		}

		_actionComplete = true;
		yield return null;
	}
}
