using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshAgent NavMeshAgent { get {  return agent; } }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        if (agent != null)
        {
            var Monster = GameObject.FindWithTag("Monster");
            agent.SetDestination(Monster.transform.position);
        }
    }

}
