using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractEventChannelListener<TEventChannel,TEventType> : MonoBehaviour where TEventChannel : GenericEventChannelSO<TEventType>
{
	[SerializeField] protected TEventChannel eventChannel;
	[SerializeField] protected UnityEvent<TEventType> Response;

	protected virtual void OnEnable()
	{
		if (eventChannel != null)
		{
			eventChannel.OnEventRaised += OnEventRaised;
		}
	}

	private void OnEventRaised(TEventType type)
	{

	}
}
