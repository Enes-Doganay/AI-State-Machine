using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AIStateID initialState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig config;
    public AIAttack aIAttack;
    public Ragdoll ragdoll;
    public Transform playerTransform;
    public Rig weaponAim;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        aIAttack = Object.FindObjectOfType<AIAttack>();
        ragdoll = GetComponentInChildren<Ragdoll>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIAttackState());
        stateMachine.RegisterState(new AIPatrolState());
        stateMachine.ChangeState(initialState);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        stateMachine.Update();
    }
}
