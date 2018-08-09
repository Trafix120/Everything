using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc5_Player : MonoBehaviour {

    // Movement
    public float moveSpeed = 20f;
    public Vector3 lastPos;

    //Camera Movement
    public float camOffSet = 10f;

    // Bullet Speed
    public float bulletSpeed = 100f;

    // Info
    public int health;
    private int[] damage;
    private float[] range;
    public Sc5_Enemy entityInfo;

    // Declaration of objects
    private Rigidbody rb;
    public Camera cam;
    public Transform moveParticle;
    public Transform moveParticlesFol;
    public Transform bullet;
    public Transform bulletFol;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lastPos = transform.position;

        health = entityInfo.health;
        damage = entityInfo.damage;
        range = entityInfo.range;
    }
	
	// Update is called once per frame
	void Update () {
        Fire();
        Debug.Log(lastPos);
	}
    private void FixedUpdate()
    {

        CamMove();
        Move();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit rayHitInfo;
            if(Physics.Raycast(ray, out rayHitInfo))
            {
                Vector3 distanceVector = rayHitInfo.point - transform.position + Vector3.up;
                distanceVector = distanceVector.normalized;
                Transform currentBullet = Instantiate(bullet, transform.position, Quaternion.identity, bulletFol);
                currentBullet.GetComponent<Rigidbody>().AddForce(distanceVector * bulletSpeed);
            }
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 force = (h * Vector3.right + v * Vector3.forward) * moveSpeed * Time.deltaTime * 10;
        rb.velocity = force;
        
    }

    private void CamMove()
    {
        cam.transform.position = transform.position + new Vector3(0, camOffSet, 0);
    }

    private void ParticleEffectsMove() {
        if (rb.velocity != Vector3.zero)
        {

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 force = (h * Vector3.right + v * Vector3.forward) * 0.5f;
            Instantiate(moveParticle, transform.position - force, Quaternion.Euler(-force), moveParticlesFol);
        }

    }
    
}
