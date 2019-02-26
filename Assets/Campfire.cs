using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
    public float torchHealth = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(torchHealth > 0)
        {
            torchHealth = torchHealth - 0.005F;
        }
        
    }
}
