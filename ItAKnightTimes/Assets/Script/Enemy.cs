using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;

    public Transform player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void follow()
    {
        Vector2 playerDir = player.position - transform.position;
        rb.velocity = playerDir * enemySpeed;
    }
}
