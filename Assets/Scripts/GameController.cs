using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Transform enemy;
    public float time;
    float timeSpan;
    Vector2 minX;
    Vector2 maxX;
    float posY;

    // Use this for initialization
    void Start ()
    {
        timeSpan = 0;
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        posY = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;

    }
	
	// Update is called once per frame
	void Update () {
        timeSpan += Time.deltaTime;
        if (timeSpan > time)
        {
            timeSpan = 0;
            Instantiate(enemy, new Vector2(Random.Range(minX.x, maxX.x), posY + 1.0f), Quaternion.identity);
        }
    }
}
