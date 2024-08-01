using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	#region Private Variables

	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Transform targetTransform;
	[SerializeField] private Animator animator;
	#endregion

	#region Properties



	#endregion

	#region LifeCycle Methods

	private void Awake()
	{

	}
	private void Start()
	{
		
	}
	private void Update()
	{
        agent.SetDestination(targetTransform.position);
		if(agent.remainingDistance <= 2f)
		{
			animator.SetBool("IsIdle", true);
			agent.speed = 0;
		}
		else
		{
            animator.SetBool("IsIdle", false);
            agent.speed = 2.5f;
		}
    }
	
	#endregion

	#region Private Methods


	#endregion

	#region Public Methods


	#endregion
}
