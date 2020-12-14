using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIUtils : MonoBehaviour
{

    /*
     * A really useful little method from this help thread https://forum.unity.com/threads/solved-random-wander-ai-using-navmesh.327950/
     * -Arthur Hertz
     */

    public static Vector3 RandomNavSphere(Vector3 origin, float maxDistanceFromSource)
    {

        Vector3 randomDirection = Random.onUnitSphere * maxDistanceFromSource;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, maxDistanceFromSource, 1);

        return navHit.position;
    }

}
