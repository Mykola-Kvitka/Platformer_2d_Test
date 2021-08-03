using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager
{


	static Dictionary<EventName, List<ZeroInvokerEvent>> zeroInvokers =
	   new Dictionary<EventName, List<ZeroInvokerEvent>>();
	static Dictionary<EventName, List<UnityAction>> zeroListeners =
		new Dictionary<EventName, List<UnityAction>>();


	static Dictionary<EventName, List<IntInvokerEvent>> intInvokers =
		new Dictionary<EventName, List<IntInvokerEvent>>();
	static Dictionary<EventName, List<UnityAction<int>>> intListeners =
		new Dictionary<EventName, List<UnityAction<int>>>();


	static Dictionary<EventName, List<FloatInvokerEvent>> floatInvokers =
		new Dictionary<EventName, List<FloatInvokerEvent>>();
	static Dictionary<EventName, List<UnityAction<float>>> floatListeners =
		new Dictionary<EventName, List<UnityAction<float>>>();

	public static void Initialize()
	{

		// create empty lists for all the dictionary entries
		foreach (EventName name in System.Enum.GetValues(typeof(EventName)))
		{
			if (!zeroInvokers.ContainsKey(name))
			{
				zeroInvokers.Add(name, new List<ZeroInvokerEvent>());
				zeroListeners.Add(name, new List<UnityAction>());
			}
			else
			{
				zeroInvokers[name].Clear();
				zeroListeners[name].Clear();
			}
		}
		foreach (EventName name in System.Enum.GetValues(typeof(EventName)))
		{
			if (!intInvokers.ContainsKey(name))
			{
				intInvokers.Add(name, new List<IntInvokerEvent>());
				intListeners.Add(name, new List<UnityAction<int>>());
			}
			else
			{
				intInvokers[name].Clear();
				intListeners[name].Clear();
			}
		}
		foreach (EventName name in System.Enum.GetValues(typeof(EventName)))
		{
			if (!floatInvokers.ContainsKey(name))
			{
				floatInvokers.Add(name, new List<FloatInvokerEvent>());
				floatListeners.Add(name, new List<UnityAction<float>>());
			}
			else
			{
				floatInvokers[name].Clear();
				floatListeners[name].Clear();
			}
		}

	}

	public static void AddZeroInvoker(EventName eventName, ZeroInvokerEvent invoker)
	{
		// add listeners to new invoker and add new invoker to dictionary
		foreach (UnityAction listener in zeroListeners[eventName])
		{
			invoker.AddListener(eventName, listener);
		}
		zeroInvokers[eventName].Add(invoker);
	}
	public static void AddZeroListener(EventName eventName, UnityAction listener)
	{
		// add as listener to all invokers and add new listener to dictionary
		foreach (ZeroInvokerEvent invoker in zeroInvokers[eventName])
		{
			invoker.AddListener(eventName, listener);
		}
		zeroListeners[eventName].Add(listener);
	}

	public static void AddIntInvoker(EventName eventName, IntInvokerEvent invoker)
	{
		// add listeners to new invoker and add new invoker to dictionary
		foreach (UnityAction<int> listener in intListeners[eventName])
		{
			invoker.AddListener(eventName, listener);
		}
		intInvokers[eventName].Add(invoker);
	}
	public static void AddIntListener(EventName eventName, UnityAction<int> listener)
	{
		// add as listener to all invokers and add new listener to dictionary
		foreach (IntInvokerEvent invoker in intInvokers[eventName])
		{
			invoker.AddListener(eventName, listener);
		}
		intListeners[eventName].Add(listener);
	}
	
	public static void AddFloatInvoker(EventName eventName, FloatInvokerEvent invoker)
	{
		// add listeners to new invoker and add new invoker to dictionary
		foreach (UnityAction<float> listener in floatListeners[eventName])
		{
			invoker.AddListener(eventName, listener);
		}
		floatInvokers[eventName].Add(invoker);
	}
	public static void AddFloatListener(EventName eventName, UnityAction<float> listener)
	{
		// add as listener to all invokers and add new listener to dictionary
		foreach (FloatInvokerEvent invoker in floatInvokers[eventName])
		{
			invoker.AddListener(eventName, listener);
		}
		floatListeners[eventName].Add(listener);
	}

	public static void RemoveInvoker(EventName eventName, ZeroInvokerEvent invoker)
	{
		// remove invoker from dictionary
		zeroInvokers[eventName].Remove(invoker);
	}

}
