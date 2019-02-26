using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Torch : MonoBehaviour
{
    public float duration = 1.0F;
    public BoxCollider box;
    public Light lt;
    private Rigidbody myRigidBody;
    float torchTimer;
    float torchGlow = 100;
    float campfireHealth;

    public AudioClip swing;
    public AudioClip cloth;
    private AudioSource add;
    private AudioSource hit;
    


    // Start is called before the first frame update

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        GameObject fire = GameObject.Find("fireplace");
        Campfire flame = fire.GetComponent<Campfire>();
        GameObject light = GameObject.FindWithTag("MainCamera");
        GameObject axe = GameObject.FindWithTag("axe");
        lt = light.GetComponent<Light>();
        box = fire.GetComponent<BoxCollider>();
        box.isTrigger = true;
        add = light.GetComponent<AudioSource>();
        hit = axe.GetComponent<AudioSource>();
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
        GameObject fire = GameObject.Find("fireplace");
        Campfire flame = fire.GetComponent<Campfire>();
        if (collision.gameObject.name == "fireplace")
        {
            if(flame.torchHealth != 0)
            {
                add.Play();
                torchGlow = 100;
            }
            
        }
       
    }

    void OnTriggerStay(Collider collision)
    {
        GameObject fire = GameObject.Find("fireplace");
        Campfire flame = fire.GetComponent<Campfire>();
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.gameObject.tag == "log")
            {
                add.Play();
                flame.torchHealth = flame.torchHealth + 2.5F;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "monster")
            {
                hit.Play();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "tree")
            {
                hit.Play();
                Destroy(collision.gameObject);
            }
        }
    }

}
