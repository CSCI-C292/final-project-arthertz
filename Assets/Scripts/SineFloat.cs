using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineFloat : MonoBehaviour
{

    [SerializeField]
    float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Random.onUnitSphere * Time.deltaTime * _speed;
    }
}
