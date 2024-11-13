using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResetManager : Resettable
{
    [SerializeField] public GameObject enemyGunner;  
    [SerializeField] public GameObject enemyBruiser; 
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
            var enemyType = EnemyType.Gunner;

            if (enemy is EnemyGunner)
            {
                enemyType = EnemyType.Gunner;
            }
            else if (enemy is EnemyBruiser)
            {
                enemyType = EnemyType.Bruiser;
            }

            enemyDataList.Add(new EnemyData
            {
                position = enemy.transform.position,
                rotation = enemy.transform.rotation,
                type = enemyType 
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
            GameObject prefabToInstantiate = null;

            switch (enemyData.type)
            {
                case EnemyType.Gunner:
                    prefabToInstantiate = enemyGunner;
                    break;

                case EnemyType.Bruiser:
                    prefabToInstantiate = enemyBruiser;
                    break;

                default:
                    continue;
            }

            Instantiate(prefabToInstantiate, enemyData.position, enemyData.rotation);
        }
    }
}

public enum EnemyType
{
    Gunner,
    Bruiser
}

public class EnemyData
{
    public Vector3 position;    
    public Quaternion rotation; 
    public EnemyType type; 
}
