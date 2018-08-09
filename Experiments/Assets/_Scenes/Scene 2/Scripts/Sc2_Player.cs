using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc2_Player : MonoBehaviour {
    // Shooting
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject particles;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float bulletForce = 100f;
    //[SerializeField] private float fireRate = 15f;
    //[SerializeField] private float nextTimeToFire = 0f;
    [SerializeField] private Animator gun;
    private float damage = 1f;
    private float range = 100f;
    private Camera cam;
    

	// Use this for initialization
	void Start () {
        cam = GetComponent<Transform>().GetChild(0).GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetButtonDown("Fire1") /*&&  Time.time >= nextTimeToFire*/)
        {
            gun.SetBool("Fire", true);
            //nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else
        {
            gun.SetBool("Fire", false);
        }
	}

    private void Shoot()
    {
        
        RaycastHit bulletHitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out bulletHitInfo, range))
        {
            Debug.Log(bulletHitInfo.transform.name);
            Sc2_Enemy target = bulletHitInfo.transform.GetComponent<Sc2_Enemy>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(bulletHitInfo.rigidbody != null)
            {
                bulletHitInfo.rigidbody.AddForce(-bulletHitInfo.normal * bulletForce);
            }
         }
        

    }
}
