using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Config")]
public class AIAgentConfig : ScriptableObject
{
    public float maxTime = 1f;
    public float maxDistance = 1f;

    public float dieForce = 10f;
    public float maxSightDistance = 5f;
}
