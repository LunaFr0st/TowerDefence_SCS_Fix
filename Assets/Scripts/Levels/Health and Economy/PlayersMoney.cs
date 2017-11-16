using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class PlayersMoney : MonoBehaviour
    {
        public int gold = 450;
        public string goldText;

        public void Update()
        {
            if (gold <= 0)
            {
                gold = 0;
            }
            if (gold > 1000000)
            {
                goldText = "1000000+";
            }
            else
            {
                goldText = gold.ToString();
            }
        }
        public void SpendGold(int amountSpent)
        {
            if(!(gold < amountSpent))
            {
                gold = gold - amountSpent;
            }
            
        }
        public void RecieveGold(int gainedGold)
        {
            gold = gold + gainedGold;
        }
    }
}

