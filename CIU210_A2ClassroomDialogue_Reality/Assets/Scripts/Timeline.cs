using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour 
{
	[SerializeField] private TimelineEvent[] _events;

	void Start()
	{
		StartCoroutine(RunTimeline());
        GlobalVariables._currentTimeline = this;
	}

	void Update()
	{
        if (GlobalVariables._currentTimeline != this)
        {
            Destroy(this.gameObject);
        }
	}

	IEnumerator RunTimeline()
	{
		for(int index = 0; index < _events.Length; index++)
		{
            TimelineEvent currentEvent = _events[index];
            bool reimporting = currentEvent._reimportEvent;

			if(!currentEvent.gameObject.activeSelf)
			{
				currentEvent.gameObject.SetActive(true);
			}

			while(!currentEvent._eventComplete)
			{
				yield return null;
			}

            Destroy(currentEvent.gameObject);
		}

		yield return null;
	}
}