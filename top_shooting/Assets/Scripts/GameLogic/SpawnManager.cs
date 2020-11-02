using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int EnemyTerm = 20;
    private int enemyTermCount = 0;

    private void Update()
    {
        if (enemyTermCount++ >= EnemyTerm)
        {
            Spawn();
            enemyTermCount = 0;
        }
    }

    private void Spawn()
    {
        var enemeyPrefab = Resources.Load("Prefabs/EnemyGroup") as GameObject;
        var enemeyObject = Instantiate(enemeyPrefab);
        enemeyObject.transform.position = transform.position;
    }
}