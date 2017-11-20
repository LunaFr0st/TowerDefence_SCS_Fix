using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {
        WaveModule wavemod;
        LevelGUIManager levelGUI;
        public int totalEnemies = 5;
        public int enemyLeftToSpawn;
        public int enemyID;
        public Transform spawnLocation;
        public GameObject[] avalEnemies;
        public float timer;
        public float spawnDelay = 0.5f;


        void Awake()
        {
            wavemod = GameObject.Find("WaveModule").GetComponent<WaveModule>();
            levelGUI = GameObject.Find("GUI").GetComponent<LevelGUIManager>();
            enemyLeftToSpawn = totalEnemies;
        }
        void Update()
        {
            if (levelGUI.waveStarted)
            {
                if (enemyLeftToSpawn > 0)
                {
                    timer += Time.deltaTime;
                    if (timer >= spawnDelay)
                    {
                        Instantiate(avalEnemies[enemyID], spawnLocation);
                        enemyLeftToSpawn--;
                        timer = 0;
                    }
                }
            }
            else
            {
                wavemod.WaveManager(5);
            }
        }
    }
}

