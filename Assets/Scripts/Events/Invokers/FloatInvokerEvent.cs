using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatInvokerEvent : MonoBehaviour
{
	protected Dictionary<EventName, UnityEvent<float>> unityEventsF =
		new Dictionary<EventName, UnityEvent<float>>();

	/// <summary>
	/// Adds the given listener for the given event name
	/// </summary>
	/// <param name="eventName">event name</param>
	/// <param name="listener">listener</param>
	public void AddListener(EventName eventName, UnityAction<float> listener)
	{
		// only add listeners for supported events
		if (unityEventsF.ContainsKey(eventName))
		{
			unityEventsF[eventName].AddListener(listener);
		}
	}
}
