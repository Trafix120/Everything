using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc3_SnakeHead : MonoBehaviour {
    //Constant Movement
    public float moveSpeed = 1f;
    public float tick = 1f;
    private float diffTime;
    public int rotation = 3;
   

    // Making the snake body parts follow the head
    public List<int> bodyPartsRotation = new List<int>();
    public Vector3 lastPos;

    //Ading Body Parts
    public GameObject parent;
    private Transform parentTrans;
    private GameObject tail;
    private Transform tailTrans;
    public GameObject pbBodyPart;

    // Proper gameplay
    public List<GameObject> goals = new List<GameObject>();
    public List<GameObject> bodyParts = new List<GameObject>();

    //Collision
    [SerializeField] GameObject mainGameManager;
    //private MainGameManager manager;

	// Use this for initialization
	void Start () {
        bodyPartsRotation.Add(3);
        bodyPartsRotation.Add(3);
        parentTrans = gameObject.GetComponent<Transform>();
        tail = bodyParts[1];
        tailTrans = tail.GetComponent<Transform>();
        //manager = mainGameManager.GetComponent<MainGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        diffTime += Time.deltaTime;
        Control();
        ConstantMovement();
        
        for(int i = 0; i < goals.Count; i++)
        {
            if (checkCollider(goals[i].gameObject, gameObject))
            {
                addBodyPart(rotation);
                goals[i].transform.position = new Vector3(0, 0, 0);
            }
        }
        

        
	}

    private void ConstantMovement()
    {
        if(diffTime >= tick)
        {
            diffTime = 0;
            lastPos = GetComponent<Transform>().position;
            if (rotation == 0)
            {
                GetComponent<Transform>().position += Vector3.up * moveSpeed;
            }
            if (rotation == 1)
            {
                GetComponent<Transform>().position += Vector3.right * moveSpeed;
            }
            if (rotation == 2)
            {
                GetComponent<Transform>().position += Vector3.down * moveSpeed;
            }
            if (rotation == 3)
            {
                GetComponent<Transform>().position += Vector3.left * moveSpeed;
            }
            
        }
    }
    
    private void Control()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if(rotation != 2)
            {
                rotation = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (rotation != 3)
            {
                rotation = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rotation != 0)
            {
                rotation = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rotation != 1)
            {
                rotation = 3;
            }
        }

    }

   
    private void checkCollider()
    {

    }

    private void addBodyPart(int rotation)
    {
        if(rotation == 0)
        {
            tail = Instantiate(pbBodyPart, tailTrans.position + (Vector3.down * moveSpeed), Quaternion.identity, parentTrans.parent);
        }
        if (rotation == 1)
        {
            tail = Instantiate(pbBodyPart, tailTrans.position + (Vector3.left * moveSpeed), Quaternion.identity, parentTrans.parent);
        }
        if (rotation == 2)
        {
            tail = Instantiate(pbBodyPart, tailTrans.position + (Vector3.up * moveSpeed), Quaternion.identity, parentTrans.parent);
        }
        if (rotation == 3)
        {
            tail = Instantiate(pbBodyPart, tailTrans.position + (Vector3.right * moveSpeed), Quaternion.identity, parentTrans.parent);
        }
        tailTrans = tail.GetComponent<Transform>();
        bodyParts.Add(tail);
    }

    private bool checkCollider(GameObject collider, GameObject other)
    {
        Transform colTrans = collider.GetComponent<Transform>();
        Transform trans = other.GetComponent<Transform>();
        
        
    
        if(colTrans.position == trans.position)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
