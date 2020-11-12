using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField]
    DialogObject welcomeToHell;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.InvokeDialogInitiated(welcomeToHell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
