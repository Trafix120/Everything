using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc6_SpawnMovingObjects : MonoBehaviour {
    public float range = 1f;
    public float frequency = 1f;
    public float timeTillSpawn;
    public Transform platform;
    public Transform movingObjectsFol;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpawn += Time.deltaTime;
        if (timeTillSpawn > frequency)
        {
            timeTillSpawn = 0;
            Debug.Log("Spawning");
            Instantiate(platform, transform.position + Vector3.up * Random.Range(-range, range), Quaternion.identity, movingObjectsFol);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position + Vector3.down * range, transform.position + Vector3.up * range);
    }
}
