using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class PlayersMoney : LevelGUIManager
    {
        protected int gold;
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
        protected void SpendGold(int amountSpent)
        {
            if(!(gold < amountSpent))
            {
                gold = gold - amountSpent;
            }
            
        }
        protected void RecieveGold(int gainedGold)
        {
            gold = gold + gainedGold;
        }
    }
}

