using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lurker : Ghost
{

    [SerializeField] float minAttackTime = 3f;

    [SerializeField] float chaseLength = 3f;

    [SerializeField] float attackProbability = .5f;
    
    [SerializeField] float baseStalkPreference = .5f;

    [SerializeField] float baseChasePreference = .5f;

    [SerializeField] AudioSource audio;

    [SerializeField] AudioClip chase;

    [SerializeField] AudioClip blinded;

    bool chasingPlayer = false;


    void Update () {
        float a = chasePlayerImportance();
        float b = stalkPlayerImportance ();

        if (a < b) {
            ChasePlayer();
        } else {
            StalkPlayer();
        }
    }


    float runAwayImportance () {
        if (blinded) return 0;
        return 1;
    }

    float stalkPlayerImportance () {
        return chasingPlayer ? 1f : baseStalkPreference;
    }

    float chasePlayerImportance () {
        return baseChasePreference + Random.Range(-attackProbability, attackProbability);
    }

    void StalkPlayer () {
        //Stalking interrupts nothing and is the default state
        if (chasingPlayer) return;
        if (blinded) return;
    }

    void ChasePlayer () {
        //Chasing interrupts stalking but not blindedness
        if (blinded) return;
        if (chasingPlayer) return;
        StartCoroutine(nameof(chaseTimer));

    }

    IEnumerator chaseTimer () {
        chasingPlayer = true;
        audio.clip = chase;
        audio.Play();
        print("Beginning chase");
        for (float timeLeft = chaseLength; timeLeft > 0; timeLeft -= Time.deltaTime) {
            //chase logic goes here
            agent.SetDestination(Player.instance.transform.position);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        print("Ending chase");
        audio.Stop();
        chasingPlayer = false;
    }

    public override void Blind (float duration) {
        base.Blind(duration);
        audio.clip = blinded;
        audio.Play();
    }
}