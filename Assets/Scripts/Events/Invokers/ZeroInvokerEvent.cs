using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZeroInvokerEvent : MonoBehaviour
{
	protected Dictionary<EventName, UnityEvent> unityEventsZ =
		new Dictionary<EventName, UnityEvent>();

	/// <summary>
	/// Adds the given listener for the given event name
	/// </summary>
	/// <param name="eventName">event name</param>
	/// <param name="listener">listener</param>
	public void AddListener(EventName eventName, UnityAction listener)
	{
		// only add listeners for supported events
		if (unityEventsZ.ContainsKey(eventName))
		{
			unityEventsZ[eventName].AddListener(listener);
		}
	}
}
