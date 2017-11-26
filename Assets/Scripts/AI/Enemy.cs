using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f; // Enemie's health which starts at 100
        public int goldToGive = 100;
        public GameObject graveStone;

        PlayersMoney money;
        WaveModule wave;
        void Awake()
        {
            money = GameObject.Find("GUI").GetComponent<PlayersMoney>();
            wave = GameObject.Find("WaveModule").GetComponent<WaveModule>();
        }
        public void DealDamage(float damage)
        {
            // SET health -= damage
            health -= damage;
            // IF health <= 0
            if (health <= 0)
            {
                // Destroy the enemy
                if(graveStone != null)
                {
                    Instantiate(graveStone, gameObject.transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
                money.RecieveGold(goldToGive);
                wave.enemiesKilled++;
                
            }
        }
    }
}