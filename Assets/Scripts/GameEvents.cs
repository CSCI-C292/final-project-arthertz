using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogEventArgs : EventArgs
{
    public DialogObject payload;

    public DialogEventArgs(DialogObject dialog)
    {
        payload = dialog;
    }
}

public static class GameEvents
{

    public static event EventHandler DialogInitiated;
    public static event EventHandler DialogFinished;


    public static void InvokeDialogInitiated(DialogObject dialog)
    {
        DialogInitiated(null, new DialogEventArgs(dialog));
    }

    public static void InvokeDialogFinished(DialogObject dialog)
    {
        DialogFinished(null, new DialogEventArgs(dialog));
    }

}
