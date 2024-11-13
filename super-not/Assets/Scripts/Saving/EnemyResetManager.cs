using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResetManager : Resettable
{
    [SerializeField] public GameObject enemy;
    [SerializeField] private List<EnemyData> enemyDataList = new List<EnemyData>();  

    private void Awake()
    {
        InitializeEnemies();  
    }

    public void InitializeEnemies()
    {
        enemyDataList.Clear();

        var enemies = FindObjectsOfType<EnemyBase>();  

        foreach (var enemy in enemies)
        {
            enemyDataList.Add(new EnemyData
            {
                position = enemy.transform.position,
                rotation = enemy.transform.rotation
            });
        }
    }

    public override void ResetHandler()
    {
        RespawnEnemies();
    }

    private void RespawnEnemies()
    {
        foreach (var enemyData in enemyDataList)
        {
            Instantiate(enemy, enemyData.position, enemyData.rotation);
        }
    }
}

[System.Serializable]
public class EnemyData
{
    public Vector3 position;    
    public Quaternion rotation; 
}
