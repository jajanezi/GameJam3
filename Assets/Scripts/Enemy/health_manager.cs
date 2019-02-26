using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_manager : MonoBehaviour {

	public int health = 10;
    public int damage = 10;
    public AudioClip deathSound;
    private Animator anim;

    public void doDamage(int damage)
	{
		this.health -= damage;
	}

    public virtual void Die()
    {
        anim.SetTrigger("death");
        Destroy(gameObject);
        AudioManager.instance.RandomizeSfx(deathSound);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
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
