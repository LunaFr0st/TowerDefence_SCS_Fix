using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {
        LevelGUIManager levelGUI;
        public int enemyLeftToSpawn;
        public int enemyID;
        private int waveNum = 0;
        public Transform spawnLocation;
        public GameObject[] avalEnemies;
        public float timer;
        public float spawnDelay = 0.5f;


        void Awake()
        {
            enemyLeftToSpawn = waveNum + 5;
            levelGUI = GameObject.Find("GUI").GetComponent<LevelGUIManager>();
        }
        //void Start()
        //{
        //    if (levelGUI.waveStarted)
        //    {
        //        InvokeRepeating("Spawner", 0, 1);
        //    }
        //}
        //void Spawner()
        //{
        //    if (enemyLeftToSpawn > 0)
        //    {
        //        
        //        enemyLeftToSpawn--;
        //    }

        //}
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


        }
        //IEnumerator WaitForSpawn()
        //{

        //    yield return new WaitForSeconds(1);
        //    if (enemyLeftToSpawn > 0)
        //    {

        //    }
        //}
    }
}

