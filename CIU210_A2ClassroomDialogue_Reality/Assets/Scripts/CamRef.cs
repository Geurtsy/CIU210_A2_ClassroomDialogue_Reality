using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRef : MonoBehaviour 
{
	public static CamRef _camRef;
	public static AudioSource _mainAudioSource;
	public GameObject _mainCam;

	void Awake()
	{
		_camRef = this;
		_mainCam = this.gameObject;
		_mainAudioSource = GetComponent<AudioSource> ();
	}
}
