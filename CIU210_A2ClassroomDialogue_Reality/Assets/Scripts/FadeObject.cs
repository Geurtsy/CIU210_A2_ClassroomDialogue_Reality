using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : Action, IAction 
{
	[SerializeField] bool _fadeIn;
	[SerializeField] Renderer _rendererToFade;
	[SerializeField] protected float _lerpTime;
	private Renderer _currentRenderer;
	private float _lerpVar;
	private Color _startColour;

	public override void Act()
	{
		_rendererToFade = _rendererToFade.GetComponent<Renderer>();
		_startColour = _rendererToFade.material.color;
	}

	protected virtual void Update()
	{
		Fade(_rendererToFade, _startColour, _lerpVar);

		if (_lerpVar < 1)
		{
			_lerpVar += Time.deltaTime / _lerpTime;
		} 
		else
		{
			_actionComplete = true;
		}
	}

	protected virtual void Fade(Renderer rend, Color startColour, float lerpVar)
	{
		if(!_fadeIn)
			rend.material.color = Color.Lerp (startColour, new Color(startColour.r, startColour.g, startColour.b, 0), lerpVar);
		else
        {
            Debug.Log(startColour + " " + startColour.a + " " + lerpVar);
            rend.material.color = Color.Lerp(startColour, new Color(startColour.r, startColour.g, startColour.b, 1.0f), lerpVar);
        }
	}
}
