using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootOnClick : MonoBehaviour
{
    [SerializeField]
    Animator gunAnimator;

    bool canFire = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            gunAnimator.SetTrigger("fireWeapon");
        }
    }
}
