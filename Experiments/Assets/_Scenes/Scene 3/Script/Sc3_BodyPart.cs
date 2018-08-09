using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc3_BodyPart : MonoBehaviour {
    public int rotation;
    public int childIndex;
    public List<int> bodyPartsRotation = new List<int>();
    public Vector3 lastPos;
    private Sc3_SnakeHead headScript;
    private float diffTime;
    private float tick;
    private GameObject parentTrans;
    // Use this for initialization
    void Start()
    {
        
        parentTrans = GetComponent<Transform>().parent.gameObject;
        headScript = parentTrans.GetComponent<Transform>().GetComponentInChildren<Sc3_SnakeHead>();
        bodyPartsRotation = headScript.bodyPartsRotation;
        rotation = bodyPartsRotation[0];
        childIndex = headScript.bodyParts.Count; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        tick = headScript.tick;
        diffTime += Time.deltaTime;
        if (diffTime >= tick)
        {
            GetComponent<Transform>().position = headScript.bodyParts[0].GetComponent<Transform>().position;

            lastPos = GetComponent<Transform>().position;
        }
        
        
    }
}
