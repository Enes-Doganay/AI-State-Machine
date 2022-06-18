using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAttackState : AIState
{
    public AIStateID GetId()
    {
        return AIStateID.AIAttack;
    }
    public void Enter(AIAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = 10f;
        agent.animator.SetBool("AIStrafe", true);
        agent.weaponAim.weight = 1f;
    }
    public void Update(AIAgent agent)
    {
        agent.navMeshAgent.destination = agent.playerTransform.position;
        agent.transform.LookAt(agent.playerTransform);
        agent.aIAttack.SetReload();
        agent.aIAttack.SetFiring();
    }
    public void Exit(AIAgent agent)
    {
    }



    
}
