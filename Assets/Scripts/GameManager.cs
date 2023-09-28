using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text scoreText;
    private int score; 
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
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
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