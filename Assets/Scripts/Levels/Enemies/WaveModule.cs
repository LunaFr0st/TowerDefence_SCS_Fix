using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class WaveModule : MonoBehaviour
    {
        public bool waveEnded = false;
        public int enemiesLeft;
        public int waveRound;

        LevelGUIManager gui;
        EnemySpawner spawner;
        void Awake()
        {
            gui = GameObject.Find("GUI").GetComponent<LevelGUIManager>();
            spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        }
        void Update()
        {
            enemiesLeft = GameObject.Find("SpawnPoint").transform.childCount;
            Debug.Log(enemiesLeft);
            
        }
        void FixedUpdate()
        {
            if (gui.waveStarted == true)
            {
                if (enemiesLeft == 0)
                {
                    waveEnded = true;
                    gui.waveStarted = !waveEnded;
                }
            }
        }
        public void WaveManager(int increaseEnemyCount)
        {
            if (waveEnded)
            {
                waveRound++;
                spawner.totalEnemies += increaseEnemyCount;
            }
        }
    }
}

