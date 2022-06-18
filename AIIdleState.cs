using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIIdleState : AIState
{
    float nextPatrolTime = 2f;
    float timer = 0f;
    public AIStateID GetId()
    {
        return AIStateID.Idle;
    }
    public void Enter(AIAgent agent)
    {
        Debug.Log(AIStateID.Idle);
    }
    public void Update(AIAgent agent)
    {
        if (Time.time >= timer)
        {
            timer = Time.time + nextPatrolTime;
            agent.stateMachine.ChangeState(AIStateID.Patrol);
        }

        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        if (playerDirection.magnitude > agent.config.maxSightDistance * agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;
        playerDirection.Normalize();
        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if(dotProduct > 0f)
        {
            agent.stateMachine.ChangeState(AIStateID.AIAttack);
        }
    }
    public void Exit(AIAgent agent)
    {
    }

    

    
}
