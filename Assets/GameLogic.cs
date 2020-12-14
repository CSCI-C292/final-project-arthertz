using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{

    [SerializeField] FloatObject keysCollected;

    [SerializeField] string winScene;

    int totalKeys;

    // Start is called before the first frame update
    void Start()
    {
        totalKeys = GameObject.FindGameObjectsWithTag("Key").Length;
        InvokeRepeating("CheckWinState", 1f, 1f);
    }

    void CheckWinState () {
        if (keysCollected.value >= totalKeys) {
            SceneManager.LoadScene(winScene);
        }
    }
}
