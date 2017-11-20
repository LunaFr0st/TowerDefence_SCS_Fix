using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class WaveModule : MonoBehaviour
    {
        public bool waveEnded = false;
        public int enemiesLeft;
        public int enemiesKilled;
        public int waveRound;
        public int totalEnemy;

        LevelGUIManager gui;
        EnemySpawner spawner;
        void Awake()
        {
            gui = GameObject.Find("GUI").GetComponent<LevelGUIManager>();
            spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        }
        void OnEnable()
        {

        }
        void Update()
        {
            enemiesLeft = GameObject.Find("SpawnPoint").transform.childCount;
            Debug.Log(enemiesLeft);
            totalEnemy = spawner.totalEnemies;
            if (gui.waveStarted)
            {
                StartCoroutine(WaveEndCheck());
                return;
            }
            else
            {
                StopAllCoroutines();
            }
            
        }
        public void WaveManager(int increaseEnemyCount)
        {
            waveRound++;
            spawner.totalEnemies += increaseEnemyCount;
        }
        IEnumerator WaveEndCheck()
        {
            yield return new WaitForSeconds(0);
            if (enemiesKilled == totalEnemy)
            {
                waveEnded = true;
                gui.waveStarted = false;
                enemiesKilled = 0;
            }
        }
    }
}

