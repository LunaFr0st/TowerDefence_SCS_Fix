﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour
    {
       
        public GameObject target;

        private NavMeshAgent nav;
        // Use this for initialization
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            target = GameObject.Find("Castle");
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                nav.SetDestination(target.transform.position);
            }
        }
    }
}
