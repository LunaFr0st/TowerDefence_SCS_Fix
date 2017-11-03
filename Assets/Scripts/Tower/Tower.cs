using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public Cannon cannon;
        public float attackRate = 0.25f;
        public float attackRadius = 5f;
        public float attackTimer = 0f;
        private List<Enemy> enemies = new List<Enemy>();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            attackTimer = attackTimer + Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0;
            }
        }
        void OnTriggerEnter(Collider col)
        {
            //Reeeeeeeeeeee Did you just assume my Collider
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                enemies.Add(e);
            }
        }
        void OnTriggerExit(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                enemies.Remove(e);
            }
        }
        Enemy GetClosestEnemy()
        {
            enemies = RemoveAllNulls(enemies);
            Enemy closest = null;
            float minDistance = float.MaxValue;
            foreach (Enemy enemy in enemies)
            {
                float distance = Vector3.Distance(cannon.transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = enemy;

                }

            }
            return closest;
        }
        void Attack()
        {
            Enemy closest = GetClosestEnemy();
            if (closest != null)
            {
                cannon.Fire(closest);
            }
        }
        List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
        {
            // LET listWithoutNulls = new List
            List<Enemy> listWithoutNulls = new List<Enemy>();


            foreach (Enemy enemies in listWithNulls)
            {
                if (enemies != null)
                {
                    listWithoutNulls.Add(enemies);
                }

            }


            return listWithoutNulls;
        }
    }
}
