using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Alibity")]
    public float enemySpeed;

    [Header("Enemy Alibity")]
    public EnemySpawner enemySpawner;

    public Animator anim;
    bool enemyDead = false;

    GameObject player;
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
        player = GameObject.Find("Player");
        Vector2 playerDir = player.transform.position - transform.position;
        rb.velocity = playerDir * enemySpeed;
    }
    public void set_up(EnemySpawner _enemySpawner)
    {
        enemySpawner = _enemySpawner;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyDead = true;
            if (enemyDead == true)
            {
                enemySpeed = 0;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
            enemySpawner.enemyDeadCount++;
            anim.Play("KuDead");
            StartCoroutine(kuDead());
        }
    }

    IEnumerator kuDead()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        enemyDead = false;
    }
}
