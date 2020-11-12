using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour
{

    TextMeshProUGUI l;

    RectTransform r;

    public float shakeSpeed = 1;

    public char currentChar;

    public float shakeAmp = 0;

    Vector3 start;

    float randomOffset;

    bool isActive = false;

    public bool endOfLine = false;


    // Start is called before the first frame update
    void Awake()
    {
        l = GetComponent<TextMeshProUGUI>();
        r = GetComponent<RectTransform>();
        start = r.localPosition;
        ClearLetter();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            r.localPosition = Mathf.Sin((shakeSpeed*6.28f) * (Time.time + randomOffset)) * shakeAmp * Vector3.up + start;
        }
        

    }
    public void InitializeLetter(char newChar, float shakeSpeed, float shakeAmp, Color letterColor)
    {
        isActive = true;
        l.text += newChar;
        this.shakeAmp = shakeAmp;
        this.shakeSpeed = shakeSpeed;
        l.color = letterColor;
        randomOffset = Random.value * 6.28f;
    }

    public void ClearLetter ()
    {
        isActive = false;
        l.text = "";
        r.localPosition = start;
    }
}
