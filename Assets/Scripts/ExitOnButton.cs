using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnButton : MonoBehaviour
{

    [SerializeField] KeyCode exitKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(exitKey)) {
            Application.Quit();
        }
    }
}
