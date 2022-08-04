using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerDead = false;
    public float gameRestart;

    public void Dead()
    {
        if (playerDead == false)
        {
            playerDead = true;
            Invoke("restart", gameRestart);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
