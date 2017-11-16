using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CastleHealth : MonoBehaviour
    {
        protected float health = 1000f;
        protected bool castleDestroyed = false;
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
        protected void recieveDamage(int damageReceived)
        {
            if(!(health <= 0))
            {
                health = health - damageReceived;
            }
        }
        protected void healCastle(int healAmount)
        {
            if(!(health <= 0))
            health = health + healAmount;
        }
    }
}

