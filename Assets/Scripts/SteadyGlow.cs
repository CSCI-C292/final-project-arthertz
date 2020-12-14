using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyGlow : MonoBehaviour
{
    public Color emissionColor;

    public Color unlitColor;

    [SerializeField]
    Color currentColor;

    Renderer r;

    private float offset;

    public float emissionStrength = 10f;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        r.material.SetColor("_EmissionColor", currentColor);
        offset = Random.Range(0, 2*Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        float lerpVal =  Mathf.Abs(Mathf.Sin(Time.time + offset));
        currentColor =   Mathf.Lerp(0, emissionStrength, lerpVal) * emissionStrength * Color.Lerp(unlitColor, emissionColor, lerpVal);
        r.material.SetColor("_EmissionColor", currentColor);
    }
}
