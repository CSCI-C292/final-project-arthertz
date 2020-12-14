using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    
    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected float minFleeDistance = 20f;

    protected bool blinded = false;

    public virtual void Blind (float duration) {
        print(name + " was blinded!");
            StartCoroutine(nameof(blindRoutine), duration   );
    }

    IEnumerator blindRoutine (float duration) {
    if (!blinded) {
        Vector3 target = transform.position;
        
        int maxIter = 200;

        while (Vector3.Distance(Player.instance.transform.position, transform.position) < minFleeDistance && maxIter-- > 0)
            target = AIUtils.RandomNavSphere(transform.position, 200);
        agent.SetDestination(target);
    }
    blinded = true;
    yield return new WaitForSeconds(duration);
    blinded = false;
    }
    
}
