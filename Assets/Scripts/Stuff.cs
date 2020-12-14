using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "new Stuff")]
public class Stuff : ScriptableObject
{
    public string itemName = "Default Name";


    public bool SameAs (Stuff other) {
        return other.itemName == itemName;
    }

}
