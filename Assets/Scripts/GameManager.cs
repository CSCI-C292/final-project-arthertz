using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName="Create New Game Manager")]
public class GameManager : ScriptableObject
{
    public void QuitApp ()
    {
        Application.Quit();
    }

    public void LoadLevel (string name)
    {
        SceneManager.LoadScene(name);
    }
}
