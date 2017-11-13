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
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Grass")
                    {
                        GameObject clone = Instantiate(towersAval[towerID], ray.GetPoint(86), Quaternion.identity);
                        clone.transform.position = new Vector3(clone.transform.position.x, 2, clone.transform.position.z);
                        Debug.Log(clone.transform.position.x + ", " + clone.transform.position.y + ", " + clone.transform.position.z);
                    }
                }
            }
        }
    }
}

