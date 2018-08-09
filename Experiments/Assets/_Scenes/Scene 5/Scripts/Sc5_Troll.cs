using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc5_Troll : MonoBehaviour {

    private int health;
    private int[] damage;
    private float[] range;
    private Transform player;
    private Vector3 distance3D;
    private float distance;
    

    private Sc5_BasicEnemy basicEnemyInfo;
	// Use this for initialization
	void Start () {
        basicEnemyInfo = GetComponent<Sc5_BasicEnemy>();
        health = basicEnemyInfo.health;
        damage = basicEnemyInfo.damage;
        range = basicEnemyInfo.range;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        distance3D = player.position - transform.position;
        distance = Mathf.Sqrt(distance3D.x) + Mathf.Sqrt(distance3D.y) + Mathf.Sqrt(distance3D.z);
        

    }
	
	// Update is called once per frame
	void Update () {
        distance = Mathf.Sqrt(distance3D.x) + Mathf.Sqrt(distance3D.y) + Mathf.Sqrt(distance3D.z);
        IsRange();
    }

    void IsRange()
    {
        for(int i = 0; i < range.Length; i++)
        {
            if(distance <= range[i])
            {
                player.GetComponent<Sc5_Player>().health -= damage[i];
            }
        }
    }
}
