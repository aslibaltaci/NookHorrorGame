using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsPlayer;

    [Space]
    [Header("Enemy AI Tweaking")]
    // Enemy AI Tweaking
    public float speed;
    public float sightRange;
    public float attackRange;

    [Space]
    [Header("Wandering")]
    // Wandering
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Space]
    [Header("Attacking")]
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [Space]
    [Header("Player Status")]
    // Player Status
    public bool playerHidden = false;
    public bool playerInSightRange, playerInAttackRange;
    public bool isStunned = false;
    public GameController player;
    public int enemyDamage = 10;

    [Space]
    [Header("Sound")]
    public AudioSource Audio;
    public AudioSource PlayerAudio;
    public AudioClip Pain;
    public AudioClip Death;

    [Space]
    [Header("Animation")]
    public GameObject run;
    public GameObject idle;



    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        /*if (isStunned) Stunned();*/
        if (isStunned)
        {
            Stunned();
        } else if (!playerHidden)
        {
            if (!playerInSightRange && !playerInAttackRange) Wandering();
            if (playerInSightRange && !playerInAttackRange) Following();
            if (playerInAttackRange && playerInSightRange) Attack();
        } else
        {
            Wandering();
        }

        if(!isStunned)
        {
            idle.SetActive(false);
            run.SetActive(true);
        }

        if(player.health == 0)
        {
            Destroy(gameObject);
            PlayerAudio.clip = Death;
            PlayerAudio.Play();
        }

    }

    private void Wandering()
    {

        if (!walkPointSet) FindWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void FindWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void Following()
    {
        agent.SetDestination(target.position);
    }
    private void Stunned()
    {
        agent.SetDestination(transform.position);
        idle.SetActive(true);
        run.SetActive(false);
    }
    private void Attack()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            ///Attack code here
            player.health -= enemyDamage;
            Audio.clip = Pain;
            Audio.Play();
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        print("test");
        alreadyAttacked = false;
    }
}