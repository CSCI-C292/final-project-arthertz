using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField]
    BunchOfStuff inventoryObject;

    [SerializeField]
    bool keepInv = false;

    [SerializeField]
    FloatObject filmCounterObject;    
    [SerializeField]
    FloatObject keyCounterObject;

    int film = 0;

    // Start is called before the first frame update
    void Start()
    {
        filmCounterObject.value = 0;
        keyCounterObject.value = 0;
        if (!keepInv) inventoryObject.listOfContents = new List<Stuff>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem (Stuff item) {
        if (item.itemName == "Film") {
            film ++;
            filmCounterObject.value = film;
            return;
        }
        
        if (item.itemName == "Key") {
            keyCounterObject.value++;
        }

        inventoryObject.listOfContents.Add(item);
    }

    public void RemoveItem (int index) {
        inventoryObject.listOfContents.RemoveAt(index);
    }

    public void RemoveItem(Stuff item) {
        inventoryObject.listOfContents.Remove(item);
    }

    public bool HasItem (Stuff item) {
        return inventoryObject.listOfContents.Contains(item);
    }

    public int GetFilm () {
        return film;
    }

    public void SetFilm (int newFilm) {
        film = newFilm;
        filmCounterObject.value = newFilm;
    }
}
