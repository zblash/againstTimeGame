using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gostergebar : MonoBehaviour {
    public static float gelendeger;
    public float ziplat;
    float degerK;
	// Use this for initialization
	void Start () {
        gelendeger = transform.position.y;
        degerK=transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.y != gelendeger)
        {
            transform.position = new Vector3(0.11f, gelendeger, 15);
        }
    }
}
