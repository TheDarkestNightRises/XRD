using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemiesRemaining;
    [SerializeField] private Player player;
    [SerializeField] private FogManager fogManager;

    public void Start()
    {
        ResetEnemiesRemaining();
    }

    public void ResetEnemiesRemaining()
    {
        enemiesRemaining = 0;
        var enemies = FindObjectsOfType<EnemyBase>();
        enemiesRemaining = enemies.Length;
        Debug.Log($"Enemies remaining: {enemiesRemaining}");

        foreach (var enemy in enemies)
        {
            enemy.onDeath.AddListener(OnEnemyDied);
        }

        player.onPlayerDeath.AddListener(HandlePlayerDeath);
    }

    private void OnEnemyDied()
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
    }

    //private void ResetLevelWithScene()
    //{
    //    Time.timeScale = 1;
    //    Time.fixedDeltaTime = 0.01f;
    //    var currentScene = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(currentScene);
    //}
}
