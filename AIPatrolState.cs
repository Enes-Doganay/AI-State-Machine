using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolState : AIState
{
    float maxAttackDistance =10f;
    float minAttackDistance = 5f;
    int wayPointIndex;
    
    WayPoints wayPoints;
    float nextPatrolTime = 0f;
    float coolDown = 1f;
    public AIStateID GetId()
    {
        return AIStateID.Patrol;
    }
    public void Enter(AIAgent agent)
    {
        wayPoints = Object.FindObjectOfType<WayPoints>();
        wayPointIndex = Random.Range(0, wayPoints.wayPoints.Length);
        Debug.Log(AIStateID.Patrol);
    }
    public void Update(AIAgent agent)
    {
        if (Vector3.Distance(agent.transform.position, wayPoints.wayPoints[wayPointIndex].transform.position) >= 1f)
        {
            agent.navMeshAgent.destination = wayPoints.wayPoints[wayPointIndex].transform.position;
        }
        else if(Vector3.Distance(agent.transform.position,wayPoints.wayPoints[wayPointIndex].transform.position) <= 1f)
        {
            agent.stateMachine.ChangeState(AIStateID.Idle);
        }
    }

    public void Exit(AIAgent agent)
    {

    }


}
