using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private FogManager fogManager;
    private int enemiesRemaining;
    private int originalEnemiesRemaining;

    private void Start()
    {
        var enemies = FindObjectsOfType<EnemyBase>();
        originalEnemiesRemaining = enemies.Length;
        enemiesRemaining = originalEnemiesRemaining;
        player.onPlayerDeath.AddListener(HandlePlayerDeath);
    }

    public void OnEnemyDied()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            HandleNextLevelTransition();
        }
    }

    private void HandleNextLevelTransition()
    {
        fogManager.ClearFog();
        GoToNextLevel();
    }

    private void HandlePlayerDeath()
    {
        HandleLevelReset();
    }

    private void HandleLevelReset()
    {
        fogManager.ClearFog();
        ResetLevel();
    }

    private void GoToNextLevel()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.01f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ResetLevel()
    {
        ResetManager.ResetScene();
        enemiesRemaining = originalEnemiesRemaining;
    }
}
