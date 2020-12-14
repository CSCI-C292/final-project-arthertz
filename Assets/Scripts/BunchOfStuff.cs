using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "new BunchOfStuff")]
public class BunchOfStuff : ScriptableObject
{
    public List<Stuff> listOfContents = new List<Stuff>();
}
