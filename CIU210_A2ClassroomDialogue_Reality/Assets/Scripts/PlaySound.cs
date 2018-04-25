using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action, IAction 
{
	[SerializeField] private AudioClip _clip;

	public override void Act ()
	{
		CamRef._mainAudioSource.PlayOneShot(_clip);
		_actionComplete = true;
	}
}
