using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc2_Bullet : MonoBehaviour {
    [SerializeField] private float bulletSpeed = 2f;
    private Quaternion currentDirection;
    private Vector3 bulletDirection;
	// Use this for initialization
	void Start () {
        currentDirection = GetComponent<Transform>().rotation;
	}
	
	// Update is called once per frame
	void Update () {
        bulletDirection = new Vector3(currentDirection.x * bulletSpeed, 0, currentDirection.z * bulletSpeed);
        GetComponent<Rigidbody>().AddForce(bulletDirection, ForceMode.VelocityChange);
        
	}
}
