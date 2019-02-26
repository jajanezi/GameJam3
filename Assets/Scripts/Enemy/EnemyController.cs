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
    private float swingDelay;
    private float counter;
    public AudioClip swingSound;
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

        counter = Time.deltaTime;
        if(distance <= lookRadius)
        {
            _agent.SetDestination(target.position);
            _animator.SetBool("run", _agent.hasPath);

            AudioManager.instance.RandomizeSfx(sandFootsteps);

            if (distance <= _agent.stoppingDistance)
           {   
                //Face target
                FaceTarget();
                //Attack target
                Attack();
           } 
        }
    }

    private void FaceTarget()
    {   
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
        AudioManager.instance.RandomizeSfx(alienNoises, null);

    }

    //triggers attack animation
    private void Attack()
    {
        if (counter > swingDelay) {
            _animator.SetTrigger("attack_1");
            swingEffects();
            counter = 0;
        }
    }

    private  void swingEffects()
    {
        this.GetComponent<AudioSource>().PlayDelayed(.0005f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
