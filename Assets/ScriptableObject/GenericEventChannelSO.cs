using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannelSO<T> : ScriptableObject
{
	public UnityAction<T> OnEventRaised;

	public void EventHappened(T parameter)
	{
		OnEventRaised?.Invoke(parameter);
	}
}
