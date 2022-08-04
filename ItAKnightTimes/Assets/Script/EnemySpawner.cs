using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn")]
    public GameObject enemy;
    public float spawnTime;
    [Header("Enemy count")]
    public float spawnCount;
    bool canSpaewn = true;


    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(spawnEnemy(spawnTime, enemy));
    }

    IEnumerator spawnEnemy(float spawnTime, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnTime);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6),0) ,Quaternion.identity);
        spawnCount++;
        if (spawnCount == 15)
        {
            canSpaewn = false;
            if (canSpaewn == false)
            {
                StopCoroutine(spawnEnemy(spawnTime, enemy));
            }
        }
        StartCoroutine(spawnEnemy(spawnTime, enemy));
    }
}
