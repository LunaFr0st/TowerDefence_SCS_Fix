using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Transform spawnLocation;
    public int enemyCount;

	void Update()
    {
        CreateNewEnemy();
    }
    public void CreateNewEnemy()
    {
        GameObject clone = Instantiate(enemies[enemyCount], spawnLocation);
    }
}
