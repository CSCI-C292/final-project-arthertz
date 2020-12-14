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

    }
}
