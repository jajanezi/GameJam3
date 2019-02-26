using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DetectingLogs : MonoBehaviour
{
    //Time wood addition should be displayed
    private float timeDisplay = 0;

    //Adding wood text ("Wood: " + woodAmount);
    protected int woodAmount = 0;

    public TextMeshProUGUI woodInventory;
    public TextMeshProUGUI woodGained;

    // Start is called before the first frame update
    void Start()
    {
        //Hides visibiliy of woodAdd text
        woodGained.SetText(" ");
    }

    // Update is called once per frame
    void Update()
    {

        //Adds amount of wood Inventory to Wood text
        woodInventory.SetText("Wood: {0}", woodAmount);


        //-----------------Wood Addition Display Logic--------------------------------------
        if (Input.GetKeyDown(KeyCode.G))
        {
            woodAmount += 2;
            woodGained.SetText("+2");
            //Adds +2 wood to wood inventory when interacting with dead wood for 1 second
            while (woodGained.text == "+2")
            {
                timeDisplay += Time.deltaTime;
                //Stop showing woodGained text after 1 second
                if (timeDisplay > 1.0f)
                {
                    woodGained.SetText("");
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            woodAmount += 5;
            woodGained.SetText("+5");
            //Adds +2 wood to wood inventory when interacting with dead wood for 1 second
            while (this.woodGained.text == "+5")
            {
                timeDisplay += Time.deltaTime;
                //Stop showing woodGained text after 1 second
                if (timeDisplay > 1.0f)
                {
                    woodGained.SetText("");
                }
            }
        }
        //-----------------Losing wood Inventory when Interacting with Campfire--------------------------------------
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "log")
                {
                    Debug.Log("This is a Log");
                }

            }
        }
    }
}
