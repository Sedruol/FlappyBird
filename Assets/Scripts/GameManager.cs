using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text restartText;
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
#if UNITY_STANDALONE
        restartText.text = "Left click to restart";
#endif
#if UNITY_ANDROID
        restartText.text = "Touch to restart";
#endif
        gameOverText.SetActive(true);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void RestartGame(InputAction.CallbackContext callbackContext)
    {
        if (isGameOver && callbackContext.performed)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}