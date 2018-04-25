using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMultiple : FadeObject, IAction 
{
	[SerializeField] private List<Renderer> _renderersToFade;

	public override void Act ()
	{
		print (_renderersToFade.Count);
		
		foreach(Renderer rend in _renderersToFade)
		{
			StartCoroutine (FadeMultipleRenderers(rend));
		}
	}

	protected override void Update ()
	{
	}

	IEnumerator FadeMultipleRenderers(Renderer rend)
	{

		Color startColour = rend.material.color;
		float lerpVar = 0;



		while(rend.material.color.a <= 1 && rend.material.color.a >= 0)
		{
			Fade(rend, startColour, lerpVar);
			print ("Test");

			if (lerpVar < 1)
				lerpVar += Time.deltaTime / _lerpTime;
			else
				_actionComplete = true;

			yield return null;
		}

		yield return null;
	}
}
