using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Action, IAction 
{
	[SerializeField] private GameObject _ignoreThis;
	[SerializeField] private Transform _explosionPos;
	[SerializeField] private float _explosionRadius;
	[SerializeField] private float _explosionForce;

	public override void Act ()
	{
		Collider[] cols = UnityEngine.Physics.OverlapSphere (_explosionPos.position, _explosionRadius);
		foreach(Collider col in cols)
		{
			if (col.gameObject != _ignoreThis)
			{
				Rigidbody rb = col.GetComponent<Rigidbody> ();

				if(rb != null)
				{
					rb.AddExplosionForce (_explosionForce, _explosionPos.position, _explosionRadius);
				}
			}
		}

		_actionComplete = true;
	}
}
