using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn")]
    public GameObject enemy;
    public float spawnTime;
    [Header("Enemy count")]
    public bool canSpawn = true;
    public Enemy enemyClass;
    public int enemyDeadCount;
    public int enemyNumber = 15;

    public Gate gate;

    public Transform enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Active? " + gameObject.activeInHierarchy);

    }

    void Update()
    {
        Debug.Log("Active? " + gameObject.activeInHierarchy);
        quit();
    }
    IEnumerator spawnEnemy(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);

        //Spawn
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(enemySpawn.transform.position.x + -5f, enemySpawn.transform.position.x + 5f),
        Random.Range(enemySpawn.transform.position.y + -3f, enemySpawn.transform.position.y + 3f), 0), Quaternion.identity);
        Enemy instEnemy = newEnemy.GetComponent<Enemy>();
        instEnemy.enemySpawner = this;
        if (enemyDeadCount < enemyNumber)
        {
            StartCoroutine(spawnEnemy(spawnTime));
        }
        if(enemyDeadCount >= enemyNumber)
        {
            StopCoroutine(spawnEnemy(spawnTime));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    public void start_spawn()
    {
        Debug.Log("Active? " + gameObject.activeInHierarchy);
        StartCoroutine(spawnEnemy(spawnTime));
    }

    void quit()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
