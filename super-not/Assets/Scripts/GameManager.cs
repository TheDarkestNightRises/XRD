using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemiesRemaining;
    [SerializeField] private PlayerOnCollision player;

    private void Start()
    {
        var enemies = FindObjectsOfType<EnemyBase>();
        enemiesRemaining = enemies.Length;
        Debug.Log($"Kill {enemiesRemaining}");

        foreach (var enemy in enemies)
        {
            enemy.onDeath.AddListener(OnEnemyDied);
        }
        player.onPlayerDeath.AddListener(ResetLevel);
    }

    private void OnEnemyDied()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            GoToNextLevel();
        }
    }

    private void GoToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
