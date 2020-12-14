using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    protected bool canInteract = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    protected virtual void Update() {
        
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) canInteract = true;
    }

    void OnTriggerExit (Collider other) {
        if (other.CompareTag("Player")) canInteract = false;
    }

    void OnTriggerStay (Collider other) {
        if (! (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))) return;
        
        Interaction(other);
    }

    virtual protected void Interaction(Collider other) {

    }
}
