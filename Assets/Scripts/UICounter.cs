using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{

    [SerializeField] string valueType = "DefaultType";

    [SerializeField] string suffix = "";

    [SerializeField] TMP_Text textbox;

    [SerializeField] FloatObject floatObject;

    // Update is called once per frame
    void Update()
    {
        textbox.text = valueType + ": " + floatObject.value + suffix;     
    }
}
