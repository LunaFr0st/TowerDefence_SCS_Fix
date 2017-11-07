using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {
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
            InvokeRepeating("IMASCRUB",3,5);
        }
        void IMASCRUB()
        {
            GameObject clone = Instantiate(avalEnemies[enemyID], spawnLocation);
            enemyLeftToSpawn--;
        }
      /*  void FixedUpdate()
        {

            if (enemyLeftToSpawn != 0)
            {
                StartCoroutine("WaitForSpawn");
            }
            else if (enemyLeftToSpawn < 0)
            {
                StopCoroutine("WaitForSpawn");
            }
        }*/
        void Spawn()
        {
            GameObject clone = Instantiate(avalEnemies[enemyID], spawnLocation);
            AIAgent cloneComp = clone.GetComponent<AIAgent>();
            enemyLeftToSpawn--;
        }
        IEnumerator WaitForSpawn()
        {
            GameObject clone = Instantiate(avalEnemies[enemyID], spawnLocation);
            enemyLeftToSpawn--;
            yield return new WaitForSeconds(2f);
            
        }
    }
}

