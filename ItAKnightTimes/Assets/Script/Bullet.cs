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

    public Transform bullPerfab;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
    }
}
