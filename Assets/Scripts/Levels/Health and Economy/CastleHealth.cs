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
        public float timer;
        public float attacktimer = 0.5f;
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
            if (health <= 0 && !playerRevive)
            {
                health = 0;
                castleDestroyed = true;
            }
        }
        public void ReceieveDamage(int damageReceived)
        {
            if(!(health <= 0))
            {
                health = health - damageReceived;
            }
        }
        public void HealCastle(int healAmount)
        {
            if(!(health <= 0))
            {
                health = health + healAmount;
            }
            
        }
        public void PlayerRevive(bool canRevive)
        {
            canRevive = playerRevive;
            if (canRevive)
            {
                money.SpendGold(reviveCost);
                castleDestroyed = false;
                health = health + 1000;
                canRevive = false;
            }
        }
        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                timer += Time.deltaTime;
                if(timer >= attacktimer)
                {
                    ReceieveDamage(1);
                    timer = 0;
                }
            }
        }
    }
}

