using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerssHealth : MonoBehaviour
{


    public int health = 100;
    public int damage = 10;
    public Transform healthBar;
    public int MAX_HEALTH = 100;


    private void Start()
    {
        //Setting the intial color of the stamina bar to green
        healthBar.GetComponent<Image>().color = new Color(0, 1, 0);
    }
    void Update()
    {
        //Changes the health bar scale when losing and gaining stamina
        healthBar.GetComponent<RectTransform>().localScale = new Vector3((health / MAX_HEALTH), 1, 1);
    }


    public void doDamage(int damage)
    {
        this.health -= damage;

        if (health < 7 && health > 3)
        {
            //Setting the color of the stamina bar to yellow
            healthBar.GetComponent<Image>().color = new Color(1, 1, 0);
        }
        else if (health < 3 && health > 0)
        {
            //Setting the color of the stamina bar to red
            healthBar.GetComponent<Image>().color = new Color(1, 0, 0);
        }
        else if (health == 0)
        {
            Die();
        }
        else 
        {
            //Health Bar is green
            healthBar.GetComponent<RectTransform>().localScale = new Vector3((health / MAX_HEALTH), 1, 1);
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        SimpleMenu.instance.Dead();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "axe")
        {

            //Debug.Log("Hit Something!");
            doDamage(damage);
            //death logic
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Die();
            }
        }
        else
        {
            Debug.Log("not hit!");
        }

    }
}
