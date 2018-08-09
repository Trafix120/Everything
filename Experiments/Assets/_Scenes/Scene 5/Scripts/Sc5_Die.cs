using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc5_Die : MonoBehaviour {
    public float time = 5f;
	// Update is called once per frame
	void Update () {
        Destroy(transform.gameObject, time);	
	}
}
