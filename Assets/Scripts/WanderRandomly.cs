using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderRandomly : MonoBehaviour
{

    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    float maxDistanceFromSource;

    [SerializeField]
    float maxIterations;


    // Start is called before the first frame update
    void Start()
    {
        //agent.SetDestination(AIUtils.RandomNavSphere(transform.position, _minRoamingDistance, _maxRoamingDistance, -1));
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            agent.SetDestination(AIUtils.RandomNavSphere(transform.position, maxDistanceFromSource));
        }
    }
}
