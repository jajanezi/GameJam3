using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    public float duration = 1.0F;
    public BoxCollider box;
    public Light lt;
    private Rigidbody myRigidBody;
    float torchTimer;
    float torchGlow = 100;
    float health = 100;
    // Start is called before the first frame update

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        GameObject fire = GameObject.FindWithTag("fireplace");
        GameObject light = GameObject.FindWithTag("MainCamera");
        lt = light.GetComponent<Light>();
        box = fire.GetComponent<BoxCollider>();
        box.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        float glow = (torchGlow/100)*0.75F;
        lt.intensity = glow;
        torchGlow = torchGlow - 0.05F;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "fireplace")
        {
            torchGlow = 100;
        }
       
    }

    void OnTriggerStay(Collider collision)
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (collision.gameObject.tag == "log")
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
