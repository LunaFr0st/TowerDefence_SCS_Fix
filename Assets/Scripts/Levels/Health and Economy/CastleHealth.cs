using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CastleHealth : MonoBehaviour
    {
        [Header("Values")]
        public float health = 1000f;
        public float maxHealth = 2000f;
        public int reviveCost = 500000;
        [Header("Booleans")]
        public bool castleDestroyed = false;
        public bool playerRevive = false;
        

        private PlayersMoney money;
        void Awake()
        {
            money = GetComponent<PlayersMoney>();
        }
        void Update()
        {
            if (health <= 0)
            {
                health = 0;
                castleDestroyed = true;
            }
            if (castleDestroyed)
            {
                health = 0;
            }
        }
        public void recieveDamage(int damageReceived)
        {
            if(!(health <= 0))
            {
                health = health - damageReceived;
            }
        }
        public void healCastle(int healAmount)
        {
            if(!(health <= 0))
            {
                health = health + healAmount;
            }
            if (playerRevive)
            {
                money.SpendGold(reviveCost);
                health = health + 1000;
            }
        }
    }
}

