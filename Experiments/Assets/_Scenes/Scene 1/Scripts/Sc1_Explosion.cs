using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc1_Explosion : MonoBehaviour {

    public float lifeSpan = 2f;
    public float power = 10f;
    public float radius = 5f;
    public float upForce = 1f;

	// Use this for initialization
	void Start () {
        Detonate();
        Destroy(gameObject, lifeSpan);
	}

    

    void Detonate()
    {
        Vector3 explosionPos = gameObject.transform.position;
        Collider[] exCollider = Physics.OverlapSphere(explosionPos, radius);
        foreach(Collider hit in exCollider)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
            }
            
        }
    }
	
}
