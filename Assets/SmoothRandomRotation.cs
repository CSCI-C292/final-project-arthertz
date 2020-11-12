using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRandomRotation : MonoBehaviour
{
    public float maxSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(Random.Range(0, maxSpeed)*Time.deltaTime, Random.onUnitSphere);
    }

    public void QuitApp ()
    {
        Application.Quit();
    }
}
