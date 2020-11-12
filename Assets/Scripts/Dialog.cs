using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : ScriptableObject
{
    public List<string> dialogElements = new List<string> ();

    public int currentLine = 0;

    public float dialogReadSpeed = 3f;

    public float punctuationReadSpeed = 1f;

    public float whitespaceReadSpeed = .5f;

    public AudioClip dialogReadNoise;
    
    public bool skippable = true;
}
