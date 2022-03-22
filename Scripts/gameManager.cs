using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 7f;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
