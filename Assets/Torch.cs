using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    public float duration = 1.0F;
    public Light lt;
    float torchTimer;
    float torchGlow = 100;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float glow = (torchGlow/100)*0.75F;
        lt.intensity = glow;
        torchGlow = torchGlow - 0.05F;
    }
}
