using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public bool playerHasEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( playerHasEnter == true )
        {
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            playerHasEnter = true;
            enemySpawner.start_spawn();
        }
    }
}
