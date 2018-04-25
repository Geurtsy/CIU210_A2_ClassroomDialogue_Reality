using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour 
{
	[SerializeField] private TimelineEvent[] _events;

	void Start()
	{
		StartCoroutine(RunTimeline());
	}

	void Update()
	{
	}

	IEnumerator RunTimeline()
	{
		foreach(TimelineEvent currentEvent in _events)
		{
			if(!currentEvent.gameObject.activeSelf)
			{
				currentEvent.gameObject.SetActive(true);
			}

			while (!currentEvent._eventComplete)
			{
				yield return null;
			}

			Destroy(currentEvent.gameObject);
		}

		yield return null;
	}

}
