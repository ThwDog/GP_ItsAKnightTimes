using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed_B;
    public float lifeTime;
    public float timer;
    Rigidbody2D rb;
    public Vector2 bullDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        rb.velocity = bullDir * speed_B;
        timer += Time.deltaTime;
        //Debug.Log(Time.deltaTime + timer);

        if(lifeTime < timer)
        {
            Destroy(gameObject);
        }
    }

}
