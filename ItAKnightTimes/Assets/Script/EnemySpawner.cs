using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn")]
    public GameObject enemy;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTime, enemy));

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawnEnemy(float spawnTime, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnTime);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6),0) ,Quaternion.identity);
        StartCoroutine(spawnEnemy(spawnTime, enemy));
    }
}
