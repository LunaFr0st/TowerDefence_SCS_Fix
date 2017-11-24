using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float deathTime = 3f;
        void Update()
        {
            Destroy(gameObject, deathTime);
        }
    }
}

