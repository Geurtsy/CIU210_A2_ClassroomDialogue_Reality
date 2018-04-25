using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour 
{
	[SerializeField] private TimelineEvent[] _events;
    private List<TimelineEvent> _eventlist;

	void Start()
	{
        for(int index = 0; index < _events.Length; index++)
        {
            _eventlist.Add(_events[index]);
        }

		StartCoroutine(RunTimeline());
	}

	void Update()
	{
	}

	IEnumerator RunTimeline()
	{
		foreach(TimelineEvent currentEvent in _eventlist)
		{
			if(!currentEvent.gameObject.activeSelf)
			{
				currentEvent.gameObject.SetActive(true);
			}

			while(!currentEvent._eventComplete)
			{
				yield return null;
			}

            _eventlist.Remove(currentEvent);
            Destroy(currentEvent.gameObject);
		}

		yield return null;
	}
}
