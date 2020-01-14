using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour {

    public float health = 50f;
    private NavMeshAgent agent;
    private Transform playerLocat;

    private bool isChasing = false;

    private void Start()
    {
        NavMeshAgent navMeshAgent = agent = GetComponent<NavMeshAgent>();//find a NavMeshAgent
    }

    private void Update()
    {
        if (isChasing == true)// if player enters collider
        {
            agent.SetDestination(playerLocat.position);//go to players location
        }

        if (health <= 0)//if dead
        {
            Destroy(gameObject);//destroy(need to animate this sometime)
        }
    }

    private void OnTriggerEnter(Collider target)//when player enters collider
    {
        if(target.tag == "Player")
        {
            playerLocat = target.transform;//set player position to target transform
            isChasing = true;
        }
    }

    public void TakeDamage(int damage)//handle damaging this AI
    {
        health -= damage;
        Debug.Log("Hit for " + damage + ". Health = " + health);
    }
}
