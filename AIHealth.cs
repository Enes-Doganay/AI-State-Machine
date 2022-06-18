using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    AIAgent agent;
    protected override void Start()
    {
        base.Start();
        agent = Object.FindObjectOfType<AIAgent>();
    }
    public override void GetDamage(float damage, Vector3 direction)
    {
        base.GetDamage(damage, direction);
        if (currentHealth <= 0)
            Die(direction);
    }
    protected override void Die(Vector3 direction)
    {
        AIDeathState deathState = agent.stateMachine.GetState(AIStateID.Death) as AIDeathState;
        agent.stateMachine.ChangeState(AIStateID.Death);
    }
}
