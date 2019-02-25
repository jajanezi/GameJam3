using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    public float lookRadius = 5f;
    public Transform target;
    int attackID = Animator.StringToHash("Attack1");
    NavMeshAgent _agent;
    public float moveSpeed;
    public AudioClip swingSound;
    public AudioClip deathSound;
    public AudioClip alienNoises;
    public AudioClip takeDamage;
    public AudioClip sandFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            _agent.SetDestination(target.position);
            _animator.SetBool("run", moveSpeed > 0);

            if (distance <= _agent.stoppingDistance)
           {   
                //Face target
                FaceTarget();
                AudioManager.instance.RandomizeSfx(sandFootsteps);
                AudioManager.instance.RandomizeSfx(alienNoises);
                //Attack target
                Attack();
           }
        }
        else
        {
            _animator.SetTrigger("idle");
        }
    }

    private void FaceTarget()
    {   
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }

    //triggers attack animation
    private void Attack()
    {     
        _animator.SetTrigger("attack_1");
        swingEffects();
    }

    private  void swingEffects()
    {
        this.GetComponent<AudioSource>().PlayDelayed(.03f);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
