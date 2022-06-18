using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIChasePlayerState : AIState
{
    float timer = 0f;
    AIStateID AIState.GetId()
    {
        return AIStateID.ChasePlayer;
    }
    void AIState.Enter(AIAgent agent)
    {

        agent.navMeshAgent.stoppingDistance = 5f;
    }
    void AIState.Update(AIAgent agent)
    {
        if (!agent.enabled)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }
        if (timer < 0f)
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            agent.transform.LookAt(agent.playerTransform);
        }
        if (Vector3.Distance(agent.playerTransform.position, agent.transform.position) <= agent.navMeshAgent.stoppingDistance)
            agent.stateMachine.ChangeState(AIStateID.AIAttack);
    }

    void AIState.Exit(AIAgent agent)
    {
    }  
}
