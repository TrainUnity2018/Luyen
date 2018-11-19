using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed;
    public Transform bullet;
    public GameObject[] bulletPosition;
    public float bulletDelay;
    public GameObject gameOverText;

    GameObject obj;
    Rigidbody2D planeRigidbody;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        obj = gameObject;
        InvokeRepeating("bulletSpawned", bulletDelay, bulletDelay);
        planeRigidbody = obj.GetComponent<Rigidbody2D>();

        anim = obj.GetComponent<Animator>();
        anim.SetBool("exploded", false);
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        planeRigidbody.velocity = new Vector2(x, y) * speed;
        if (obj.transform.position.x < -2.0f)
        {
            Vector3 oldPosition = obj.transform.position;
            oldPosition.x = -2.0f;
            obj.transform.position = oldPosition;
        }
        if (obj.transform.position.x > 2.0f)
        {
            Vector3 oldPosition = obj.transform.position;
            oldPosition.x = 2.0f;
            obj.transform.position = oldPosition;
        }
        if (obj.transform.position.y < -4.72f)
        {
            Vector3 oldPosition = obj.transform.position;
            oldPosition.y = -4.72f;
            obj.transform.position = oldPosition;
        }
        if (obj.transform.position.y > 4.0f)
        {
            Vector3 oldPosition = obj.transform.position;
            oldPosition.y = 4.0f;
            obj.transform.position = oldPosition;
        }
    }
    void bulletSpawned()
    {
        foreach (var Bullet in bulletPosition)
        {
            Instantiate(bullet, Bullet.transform.position, Bullet.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D opponent)
    {
        Debug.Log("Hit hit");
        if (opponent.tag.Equals("Enemy"))
        {
            Debug.Log("Hit enemy");
            gameOverText.gameObject.SetActive(true);
            anim.SetBool("exploded", true);
            //Time.timeScale = 0;
        }
    }
}
