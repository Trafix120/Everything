using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc4_Asteroids : MonoBehaviour {

    // Falling to player
    [SerializeField] Transform target;
    [SerializeField] float targetSpeed = 5f;
    

    // Gameplay
    public int health = 5;
    private TextMesh text;

    //SlowDownTime
    private float originSpeed;
    [SerializeField] private float slowSpeed = 1f;

    // Upgrades
    [SerializeField] private RectTransform upgradeMenu;


    //Standard
    private Transform trans;
    private Sc4_LaunchingStation targetScript;

	// Use this for initialization
	void Start () {
        upgradeMenu = GameObject.FindGameObjectWithTag("Upgrade Menu").GetComponent<RectTransform>();
        trans = GetComponent<Transform>();
        text = GetComponentInChildren<TextMesh>();
        originSpeed = targetSpeed;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetScript = target.GetComponent<Sc4_LaunchingStation>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 distance = target.position - trans.position;
        trans.position = Vector3.Lerp(trans.position, target.position, targetSpeed * Time.deltaTime / distance.magnitude);
        
    }

    private void Update()
    {
        text.text = health.ToString();
        checkTimeSlowDown();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateItems()
    {
        slowSpeed = upgradeMenu.GetComponent<Sc4_UpgradesMenu>().slowDownMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            health--;
            Destroy(collision.gameObject);
        }
    }

    private void checkTimeSlowDown()
    {
        
        if(!targetScript.fire)
        {
            targetSpeed = originSpeed;
        }
        if(targetScript.fire)
        {
            targetSpeed = slowSpeed;
        }


    }

    
   
}
