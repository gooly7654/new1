using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject targetsParent; // Assign the "Targets" GameObject here
    public Text timerText;
    public Text timeText; // Reference to the Time Text UI element in the EndLevelPanel
    public GameObject endLevelPanel; // Reference to the EndLevelPanel
    public int totalTargets = 5;

    private float timer;
    private int targetsHit;
    private LevelManager levelManager; // Reference to LevelManager

    void Start()
    {
        timer = 0f;
        targetsHit = 0;
        endLevelPanel.SetActive(false); // Hide the end level panel initially
        levelManager = FindObjectOfType<LevelManager>(); // Find LevelManager in the scene
    }

    void Update()
    {
        if (targetsHit >= totalTargets)
        {
            StopTimer();
        }
        else
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void TargetHit()
    {
        targetsHit++;
    }

    void UpdateTimerText()
    {
        timerText.text = $"Time: {Mathf.Round(timer)}s";
    }

    void StopTimer()
    {
        timerText.text = $"Time: {Mathf.Round(timer)}s";
        timeText.text = $"You took {Mathf.Round(timer)} seconds!";
        endLevelPanel.SetActive(true); // Show the end level panel
        Time.timeScale = 0; // Pause the game
    }

    public void PlayAgain()
    {
        Debug.Log("Play Again button clicked!");
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void NextLevel()
    {
        Time.timeScale = 1; // Resume the game
        if (levelManager != null)
        {
            levelManager.LoadNextLevel(); // Load the next level
        }
    }
}
