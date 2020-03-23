using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public float attackRange;
    private NavMeshAgent navMeshAgent;
    public Animator animator;
    public int points = 5;

    public int maxHealth;
    private int currHealth;
    //game manager reff
    public GameManager gameManager;
    //spawner code
    private GameObject objSpawn;
    private int SpawnerID;

    //public int damage;
    public State monsterState = State.ALIVE;

    public float sinkSpeed;

    public enum State
    {
        ALIVE, DYING, 
    } 

    


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
        currHealth = maxHealth;
    }

    void setName(int sName)
    {
        SpawnerID = sName;
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        Vector3 distanceVector = transform.position - player.transform.position;
        distanceVector.y = 0;
        float distance = distanceVector.magnitude;

        if (distance <= attackRange)
        {
            animator.SetBool("Attack", true);
        }

        if (monsterState == State.ALIVE)
        {

        }
        
        

    }

    public void Attack()
    {
        //audioSource.PlayOneShot(hitClip);
    }

    public void Hurt(int damage)
    {
        if (monsterState == State.ALIVE)
        {
            animator.SetTrigger("Hurt");
            currHealth -= damage;
            if (currHealth <= 0)
                Die();
            
        }
    }

    void Die()
    {
        monsterState = State.DYING;
        //audioSource.PlayOneShot(dieClip);
        navMeshAgent.isStopped = true;
        animator.SetTrigger("Dead");
        objSpawn.BroadcastMessage("killEnemy", SpawnerID);
        Destroy(gameObject, 5f);
        gameManager.AddScore(points);
    }

    
}
