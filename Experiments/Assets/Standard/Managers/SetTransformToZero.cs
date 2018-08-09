using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformToZero : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<RectTransform>().position = Vector3.zero;
        GetComponent<RectTransform>().rotation = Quaternion.identity;
	}
	
	
}
