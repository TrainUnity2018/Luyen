using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    GameObject obj;
    public float velocity;
	// Use this for initialization
	void Start () {
        obj = gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        obj.transform.position += new Vector3(0, velocity, 0);
	}

    
}
