using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Stamina : MonoBehaviour
{
    public Transform StaminaBar;
    const float MAX_STAMINA = 10;
    public float currentStamina = 10;

    //Heart images that will be destroyed when player takes damage
    public List<Transform> hearts = new List<Transform>();

    //Player object to control UI logic
    public GameObject player;

    //Adding wood text ("Wood: " + woodAmount);
    public bool showWoodAdd = false;
    protected int woodAmount = 0;

    public TextMeshProUGUI woodInventory;
    public TextMeshProUGUI woodGained;

    //Time
    private float timeCheck = 0;
    private float timeDisplay = 0;

    //Hearts Left
    public int heartsLeft = 3;


    void Start()
    {
        //Setting the intial color of the stamina bar
        StaminaBar.GetComponent<Image>().color = new Color(0, 1, 0);


        //Hides visibiliy of woodAdd text
        woodGained.SetText("");
    }
    
    void Update()
    {
        //Adds amount of wood Inventory to Wood text
        woodInventory.SetText("Wood: {0}", woodAmount);

        //Changes the stamina bar scale when losing and gaining stamina
        StaminaBar.GetComponent<RectTransform>().localScale = new Vector3((currentStamina/MAX_STAMINA), 1, 1);

        //-----------------Changing Stamina Bar Scale-----------------------------
        //Decreasing the stamina bar when the 'run' button is held down
        if (Input.GetKey(KeyCode.LeftShift))
        {

            //Want to alter the stamina bar in real-time
            timeCheck += Time.deltaTime;
            if (timeCheck > 0)
            {
                currentStamina -= 0.05f;
                timeCheck = 0;
            }
        }
        else {
            //Regenerate the stamina bar when 'run' button isn't held down
            if (currentStamina < MAX_STAMINA) {
               currentStamina += 0.05f;
            }  
        }

        //-----------------Changing Stamina Bar Scale Color------------------------

        if (currentStamina < 7 && currentStamina > 3)
        {
            //Change color to Yellow
            StaminaBar.GetComponent<Image>().color = new Color(1, 1, 0);

        }
        else if (currentStamina < 3 && currentStamina > 0)
        {
            //Change color to Red
            StaminaBar.GetComponent<Image>().color = new Color(1, 0, 0);
        }
        else if (currentStamina <= 0) {
            currentStamina = 0;

            //Makes the player begin walking when ran out of stamina
            if (currentStamina == 0) {
                
            }
        }


        //-----------------Losing Health Logic--------------------------------------

        //Logic for PLayer losing health when colliding with an enemy
        //If an enemy hits the player, delete one of the heart images from the hearts[] array
        if (heartsLeft != 0 && Input.GetKeyDown(KeyCode.R))
        {

            //Hides the hearts visibilty when player loses health
            hearts[heartsLeft - 1].gameObject.active = false;
            hearts.RemoveAt(heartsLeft - 1);
            heartsLeft--;
        }


        //-----------------Wood Addition Display Logic--------------------------------------
        if (Input.GetKeyDown(KeyCode.D))
        {
            woodAmount += 2;
            showWoodAdd = true;
            woodGained.SetText("+2");
            //Adds +2 wood to wood inventory when interacting with dead wood for 1 second
            while (showWoodAdd)
            {
                timeDisplay += Time.deltaTime;
                //Stop showing woodGained text after 1 second
                if (timeDisplay > 1.0f)
                {
                    woodGained.SetText("");
                    showWoodAdd = false;
                }
            }             
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            woodAmount += 5;
            showWoodAdd = true;
            woodGained.SetText("+5");
            //Adds +2 wood to wood inventory when interacting with dead wood for 1 second
            while (showWoodAdd)
            {
                timeDisplay += Time.deltaTime;
                //Stop showing woodGained text after 1 second
                if (timeDisplay > 1.0f)
                {
                    woodGained.SetText("");
                    showWoodAdd = false;
                }
            }
        }
        //-----------------Losing wood Inventroy when Interacting with Campfire--------------------------------------









    }
}

