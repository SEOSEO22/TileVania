using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;

    private void Awake()
    {
        int sessionNumber = FindObjectsOfType<GameSession>().Length;

        if (sessionNumber > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayerDeath()
    {
        if (playerLife > 1)
        {
            Die();
        }
        else
        {
            ResetGame();
        }
    }

    void Die()
    {
        playerLife--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
