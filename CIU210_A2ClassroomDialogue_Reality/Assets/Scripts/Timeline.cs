using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour 
{
	[SerializeField] private TimelineEvent[] _events;
    private List<TimelineEvent> _eventlist;

	void Start()
	{
        _eventlist = new List<TimelineEvent>();

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

            if(reimporting == true)
            {
                Reimport(index);
                break;
            }
		}

		yield return null;
	}

    void Reimport(int indexUpdatingTo)
    {
        for(int index = 0; index <= indexUpdatingTo; index++)
        {
            _eventlist.Remove(_events[index]);
        }

        _events = _eventlist.ToArray();

        StartCoroutine(RunTimeline());
    }
}
