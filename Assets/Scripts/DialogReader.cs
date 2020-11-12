using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;

public class DialogReader : MonoBehaviour
{

    [SerializeField]
    List<Letter> letters = new List<Letter>();

    int currentLetter;

    List<int> lineBreaks = new List<int>();

    void Awake()
    {
        GameEvents.DialogInitiated += ReadDialog;
    }


    private void ReadDialog (object sender, EventArgs e)
    {
        DialogEventArgs d = (DialogEventArgs)e;
        DialogObject dialog = d.payload;
        StartCoroutine(HandleDialogBroadcast(dialog));
    }


    [ContextMenu("Get Letters From Children")]
    private void GetLetters ()
    {
        letters = new List<Letter>();

        Letter[] childLetters = transform.GetComponentsInChildren<Letter>();

        foreach (Letter l in childLetters)
        {
            letters.Add(l);
        }

        UpdateLineBreaks();
    }

    private string[] GetWords (String s)
    {
        return s.Split(' ');
    }


    void UpdateLineBreaks ()
    {
        lineBreaks = new List<int>();

        //Find line breaks
        for (int i = 0; i < letters.Count; i++)
        {
            if (letters[i].endOfLine)
            {
                lineBreaks.Add(i);
            }
        }
    }

    [ContextMenu("Test Dialog")]
    private void DialogTest()
    {
        DialogObject test = new DialogObject();

        test.shakeAmp = .2f;

        test.dialogLines.Add("Lorem ipsum this is a test");

        GameEvents.InvokeDialogInitiated(test);
    }


    private IEnumerator HandleDialogBroadcast (DialogObject dialog)
    {

        foreach (string s in dialog.dialogLines)
        {
            if (letters.Count < s.Length)
            {
                print("Dialog reader not long enough for this message! Add more letters");
            }
            else
            {
                print(s);
                int index_letters = 0;
                foreach (string w in GetWords(s))
                {
                    int index_word = 0;
                    int wordLength = w.Length;

                    while (index_word < wordLength)
                    {
                        letters[index_letters].InitializeLetter(w[index_word], dialog.shakeSpeed, dialog.shakeAmp, dialog.textColor);

                        yield return new WaitForSeconds(dialog.textReadSpeed);

                        index_letters++;
                        index_word++;
                    }

                    letters[index_letters].InitializeLetter(' ', dialog.shakeSpeed, dialog.shakeAmp, dialog.textColor);
                    index_letters++;

                    yield return new WaitForSeconds(dialog.pauseBetweenWords);
                }
                yield return new WaitForSeconds(dialog.pauseBetweenLines);
                foreach (Letter l in letters) { l.ClearLetter(); }
            }
        }
    }
}
