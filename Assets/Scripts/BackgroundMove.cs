using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {
    public float moveSpeed = 2;
    public double moveRange = 12;

    public Vector3 oldPosition;
    GameObject obj;
    
	// Use this for initialization
	void Start () {
        obj = gameObject;
        oldPosition = obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        obj.transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
	}
}
