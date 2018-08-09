using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc6_MovingObjects : MonoBehaviour {
    public float speed = 1f;        // The objects speed
    public bool move = true;        // Whether or not the objects move

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += Vector3.left * speed;
        }
    }
}
