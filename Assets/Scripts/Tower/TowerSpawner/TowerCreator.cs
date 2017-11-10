using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class TowerCreator : MonoBehaviour
    {
        public Camera cam;
        public GameObject[] towersAval;
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(mousePos);
                if(Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name);
                    if(hit.transform.tag == "Grass")
                    {
                        mousePos.y = 2;
                        Instantiate(towersAval[0], mousePos/2, Quaternion.identity);
                    }
                }
            }
        }
    }
}

