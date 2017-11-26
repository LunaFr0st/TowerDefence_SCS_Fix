using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class TowerCreator : MonoBehaviour
    {
        public Camera cam;
        public GameObject[] towersAval;
        public int towerID = 0;
        public int towerCost;
        public bool canPlace = false;


        LevelGUIManager gui;
        PlayersMoney money;
        void Awake()
        {
            gui = GameObject.Find("GUI").GetComponent<LevelGUIManager>();
            money = GameObject.Find("GUI").GetComponent<PlayersMoney>();
        }
        void Update()
        {
            canPlace = !gui.waveStarted;
            if(gui.towerIsSelected)
            {
                if (towerID == 0)
                {
                    towerCost = 225;
                }
                else
                {
                    towerCost = 500;
                }
                if (money.gold >= towerCost)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.tag == "Grass")
                            {
                                GameObject clone = Instantiate(towersAval[towerID], ray.GetPoint(86), Quaternion.identity);
                                clone.transform.position = new Vector3(clone.transform.position.x, 3, clone.transform.position.z);
                                Debug.Log(clone.transform.position.x + ", " + clone.transform.position.y + ", " + clone.transform.position.z);
                                money.SpendGold(towerCost);
                                gui.towerIsSelected = false;
                            }
                        }
                    }
                }
            }
        }
    }
}

