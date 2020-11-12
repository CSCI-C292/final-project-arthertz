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

    public static Vector3 RandomNavSphere(Vector3 origin, float maxDistanceFromSource, float maxDistanceFromTarget, int layermask, int sampleDepth)
    {
        Vector3 result = origin;

        Vector3 randomDirection;

        NavMeshHit navHit;

        while (sampleDepth > 0) {
            randomDirection = UnityEngine.Random.onUnitSphere * maxDistanceFromSource;

            randomDirection.y = 0;

            randomDirection += result;

            NavMesh.SamplePosition(randomDirection, out navHit, maxDistanceFromTarget, layermask);

            result =  navHit.position;

            sampleDepth--;
        }
        return result;
    }

}
