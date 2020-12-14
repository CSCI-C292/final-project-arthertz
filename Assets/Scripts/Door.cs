using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    [SerializeField]
    Stuff key;
    
    bool isLocked = true;

    private void Open() {
        gameObject.SetActive(false);
    }

    override protected void Interaction(Collider other) {

        if (!key) {
            Open();
        }

        if (other.gameObject.GetComponent<PlayerInventory>().HasItem(key)) {
            Open();
        }
    }
}
