using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc4_LaunchingStation : MonoBehaviour {
    // Rotation
    [SerializeField] private float maxRotation;
    [SerializeField] private float rotationSpeed = 60;
    private float currentRotation;
    private int direction = 1;

    // Animation of arrows
    [SerializeField] private Transform[] arrows;
    [SerializeField] private float arrowTime;
    [SerializeField] private Color normArrowColor;
    [SerializeField] private Color transparentColor;
    private int currentNoArrows = 0;

    // Fire
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileFol;
    private float projectileSpeed = 500f;
    public int maxShot = 10;
    private float originRotationSpeed;
    public bool fire;



    // Upgrades menu
    public Transform upgradeMenu;

    // Normal things
    private Transform trans;
    private float btwTime;
    private Transform mainGameManager;

    // Use this for initialization
    void Start () {
        fire = false;
        trans = GetComponent<Transform>();
        mainGameManager = GameObject.FindGameObjectWithTag("GameController").transform;
        originRotationSpeed = rotationSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Rotation();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rotationSpeed = 0;
            StartCoroutine("constantShooting");
        }

        UpdateItems();
    }

    private void UpdateItems()
    {
        maxShot = upgradeMenu.GetComponent<Sc4_UpgradesMenu>().ammo;
    }

    private void Rotation()
    {
        btwTime += Time.deltaTime;
        // <Rotation side to side start>
        if (currentRotation <= maxRotation && currentRotation >= -maxRotation)
        {
            currentRotation += rotationSpeed * Time.deltaTime * direction;
        }
        else
        {
            direction *= -1;
            currentRotation += rotationSpeed * Time.deltaTime * direction;
        }
        trans.rotation = Quaternion.Euler(0, 0, currentRotation);
        // <Rotation side to side End>

        // <Show Arrows Start>
        if (btwTime > arrowTime)
        {
            if (currentNoArrows < 3)
            {
                arrows[currentNoArrows].GetComponent<SpriteRenderer>().color = normArrowColor;
                currentNoArrows++;
            }
            else
            {
                for (int i = 1; i < arrows.Length; i++)
                {
                    
                    arrows[i].GetComponent<SpriteRenderer>().color = transparentColor;
                }
                currentNoArrows = 0;
            }
            btwTime = 0;
        }
        // <Show Arrows End>
    }

    IEnumerator constantShooting()
    {
        for (int i = 0; i < maxShot; i++)
        {
            fire = true;
            GameObject rock = Instantiate(projectile, trans.position, trans.rotation, projectileFol.transform);
            rock.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
            if((i + 1) == maxShot)
            {
                rotationSpeed = originRotationSpeed;
                fire = false;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
