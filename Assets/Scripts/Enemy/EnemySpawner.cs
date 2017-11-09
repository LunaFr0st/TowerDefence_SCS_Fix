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


        void Awake()
        {
            enemyLeftToSpawn = 5;
        }
        void Start()
        {
            //if (levelGUI.waveStarted)
            //{
                
            //}
            InvokeRepeating("Spawner", 0, 1);

        }
        void Spawner()
        {
            if(enemyLeftToSpawn > 0)
            {
                GameObject clone = Instantiate(avalEnemies[enemyID], spawnLocation);
                enemyLeftToSpawn--;
            }
            
        }
        //void FixedUpdate()
        //{
        //    //StartCoroutine(WaitForSpawn());
        //}
        //void Spawn()
        //{
        //    GameObject clone = Instantiate(avalEnemies[enemyID], spawnLocation.transform);
        //    AIAgent cloneComp = clone.GetComponent<AIAgent>();
        //    enemyLeftToSpawn--;
        //}
        //IEnumerator WaitForSpawn()
        //{
        //    enemyLeftToSpawn--;
        //    yield return new WaitForSeconds(5);
        //    GameObject clone = Instantiate(avalEnemies[enemyID], spawnLocation.transform);

        //}
    }
}

