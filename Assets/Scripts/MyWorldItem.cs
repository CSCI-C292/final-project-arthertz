using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWorldItem : Interactable
{


    [SerializeField]
    Stuff representedObject;


    protected override void Interaction (Collider other) {

        AudioSource source;

        TryGetComponent<AudioSource>(out source);

        source.Play();

        other.GetComponent<PlayerInventory>().SendMessage("AddItem", representedObject);

        transform.position = Vector3.up * 9999f;
        Destroy(gameObject, source.clip.length);
    }
}
