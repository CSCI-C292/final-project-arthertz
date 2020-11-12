using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootOnClick : MonoBehaviour
{
    [SerializeField]
    Animator gunAnimator;

    [SerializeField]
    Camera ghostCamera;

    bool canFire = true;

    [SerializeField]
    float flickerTime = .1f;

    [SerializeField]
    AudioClip playOnFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            gunAnimator.SetTrigger("fireWeapon");
            StartCoroutine(FlickerCamera());
        }
    }


    IEnumerator FlickerCamera () {
        ghostCamera.gameObject.SetActive(true);

        GetComponent<AudioSource>().PlayOneShot(playOnFire);

        yield return new WaitForSeconds(flickerTime);

        ghostCamera.gameObject.SetActive(false);
    }
}
