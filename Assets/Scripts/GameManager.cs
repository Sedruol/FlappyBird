using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    public bool isGameOver = false;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}