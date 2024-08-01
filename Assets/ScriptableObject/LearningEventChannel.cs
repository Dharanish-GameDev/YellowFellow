using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SampleEventSO")]
public class LearningEventChannel : GenericEventChannelSO<SampleEvent>
{
	
}

[System.Serializable]
public struct SampleEvent
{
	public SamplePlayer SamplePlayer;

	public SampleEvent(SamplePlayer samplePlayer)
	{
		SamplePlayer = samplePlayer;
	}
}
