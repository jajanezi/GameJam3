using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Hearts Left
    public int heartsLeft = 3;

    //Heart images that will be destroyed when player takes damage
    public List<Transform> hearts = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //-----------------Losing Health Logic--------------------------------------

        //Logic for PLayer losing health when colliding with an enemy
        //If an enemy hits the player, delete one of the heart images from the hearts[] array
        if (heartsLeft != 0 && Input.GetKeyDown(KeyCode.R))
        {

            //Hides the hearts visibilty when player loses health
            hearts[heartsLeft - 1].gameObject.SetActive(false);
            heartsLeft--;
            Debug.Log(heartsLeft);
        }
        else if (heartsLeft == 0)
        {
            

        }
    }
}
