﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f; // Enemie's health which starts at 100

        public void DealDamage(float damage)
        {
            // SET health -= damage
            health -= damage;
            // IF health <= 0
            if (health <= 0)
            {
                // Destroy the enemy
                Destroy(gameObject);
            }
        }
    }
}