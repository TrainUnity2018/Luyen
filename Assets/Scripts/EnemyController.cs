using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    GameObject obj;
    Rigidbody2D enemyRigidbody;
    Animator anim;

    public float velocity;


	// Use this for initialization
	void Start () {
        obj = this.gameObject;
        enemyRigidbody = obj.GetComponent<Rigidbody2D>();
        anim = obj.GetComponent<Animator>();
        anim.SetBool("exploded",false);
	}
	
	// Update is called once per frame
	void Update () {
        obj.transform.position += new Vector3(0, -velocity, 0);
	}

    private void OnTriggerEnter2D(Collider2D opponent)
    {
        if (opponent.tag.Equals("Bullet"))
        {
            Debug.Log("Hit bullet");
            anim.SetBool("exploded", true);
            //Time.timeScale = 0;
            velocity = 0;
        }
    }
}
