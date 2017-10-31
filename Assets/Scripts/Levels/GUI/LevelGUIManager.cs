using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class LevelGUIManager : MonoBehaviour
    {
        //Variables
        public GUIStyle background = new GUIStyle();
        int sW; // Screen Width
        int sH; // Screen Height

        //Functions
        void Awake()
        {

        }
        void Update()
        {
            sW = Screen.width / 16;
            sH = Screen.height / 9;
        }
        void OnGUI()
        {
            GUI.Box(new Rect(sW,sH,sW,sH),"");
        }
    }
}

