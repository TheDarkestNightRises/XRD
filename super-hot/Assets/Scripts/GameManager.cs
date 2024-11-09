using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemiesRemaining;
    [SerializeField] private PlayerOnCollision player;
    [SerializeField] private FogManager fogManager;
    [SerializeField] private float resetDelay = 0.7f;

    private void Start()
    {
        var enemies = FindObjectsByType<EnemyBase>(FindObjectsSortMode.None);
        enemiesRemaining = enemies.Length;
        Debug.Log($"Kill {enemiesRemaining}");

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
            StartCoroutine(HandleNextLevelTransition());
        }
    }

    private IEnumerator HandleNextLevelTransition()
    {
        fogManager.SetFog();
        yield return new WaitForSeconds(resetDelay);
        GoToNextLevel();
    }

    private void HandlePlayerDeath()
    {
        StartCoroutine(HandleLevelReset());
    }

    private IEnumerator HandleLevelReset()
    {
        fogManager.SetFog();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(resetDelay);
        Time.timeScale = 1;
        ResetLevel();
    }

    private void GoToNextLevel()
    {
        Time.timeScale = 1; 
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
