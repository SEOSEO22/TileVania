using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;

    int scoreNum = 0;

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

    private void Start()
    {
        lifeText.text = playerLife.ToString("D2");
        scoreText.text = scoreNum.ToString("D6");
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

    public void AddScore(int score)
    {
        scoreNum += score;

        scoreText.text = scoreNum.ToString("D6");
    }

    void Die()
    {
        playerLife--;
        lifeText.text = playerLife.ToString("D2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
