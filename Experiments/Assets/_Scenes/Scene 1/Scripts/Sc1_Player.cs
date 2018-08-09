using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc1_Player : MonoBehaviour {
    //Movement
    public int playerSpeed = 20;
    public Vector3 inputSpeed;
    public Texture mouseTexture;

    //Explosion
    public GameObject explosion;
    private Camera cam;
    public GameObject GameManager;
    private TimeManager timeManager;
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    

    // Use this for initialization
    void Start () {
        
        
        cam = GetComponentInChildren<Camera>();
        timeManager = GameManager.GetComponent<TimeManager>();
        if(timeManager == null)
        {
            print("timeManager Null");
        }
        
        
	}

    
    // Update is called once per frame
    void Update () {
       if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 5, Screen.height / 2 - 5, 10, 10), mouseTexture);
       
    }

    private void Shoot()
    {
        RaycastHit _hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo))
        {
            Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
            timeManager.TimeConfig(slowDownFactor, slowDownLength);
        }

        

    }
}
