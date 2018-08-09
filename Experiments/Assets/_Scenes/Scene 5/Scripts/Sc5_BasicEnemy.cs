using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sc5_BasicEnemy : MonoBehaviour {
    private NavMeshAgent navMeshAgent;
    private Transform player;
    public Sc5_Enemy entityInfo;

    public int health;
    public int[] damage;
    public float[] range;
    

	// Use this for initialization
	void Start () {
        navMeshAgent = transform.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = entityInfo.health;
        damage = entityInfo.damage;
        range = entityInfo.range;
	}
	
	// Update is called once per frame
	void Update () {
        navMeshAgent.SetDestination(player.position);

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
