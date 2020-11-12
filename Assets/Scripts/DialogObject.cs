using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue")]
public class DialogObject : ScriptableObject
{

    public float textReadSpeed = .1f;

    public float shakeAmp = 2;

    public float shakeSpeed = 2;

    public float pauseBetweenLines = 1f;

    public float pauseBetweenWords = .5f;

    public Color textColor = Color.white;

    public List<string> dialogLines = new List<string>();
}
