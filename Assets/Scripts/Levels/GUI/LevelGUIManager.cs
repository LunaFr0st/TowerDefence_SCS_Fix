using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class LevelGUIManager : MonoBehaviour
    {
        [System.Serializable]
        public class LerpManifold
        {
            public float current = 17;
            public float begin = 10;
            public float end = 17;
            public float smoothness = 1f;
            public LerpManifold() { }
            public LerpManifold(float current, float begin, float end, float smoothness)
            {
                this.current = current;
                this.begin = begin;
                this.end = end;
                this.smoothness = smoothness;
            }
            public float GetValue(bool toggle)
            {
                if (toggle)
                    current = Mathf.Lerp(current, begin, smoothness * Time.deltaTime);
                else
                    current = Mathf.Lerp(current, end, smoothness * Time.deltaTime);
                return current;
            }
        }

        //Variables
        public GUIStyle background = new GUIStyle();
        public GUIStyle button = new GUIStyle();
        public GUIStyle Logo = new GUIStyle();
        public LerpManifold panelManifold = new LerpManifold();
        public LerpManifold contentManifold = new LerpManifold();
        public LerpManifold buttonManifold = new LerpManifold(15.5f, 15.5f, 9.5f, 1);
        int sW; // Screen Width
        int sH; // Screen Height
        bool showInv = false; // shows the Buy/Sell Menu in-game
        bool showButton = true; // enables/Disable the button for showing the buy/sell menu
        Rect panelRect;
        Rect logoRect;
        Rect healthRect;
        Rect moneyRect;

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
            // Background Panel
            float panelX = panelManifold.GetValue(showInv);
            panelRect = new Rect(panelX * sW, 0, 6.5f * sW, 9.5f * sH);
            GUI.Box(panelRect, "", background); // REKKKTTT

            //ContentPanel
            float contentX = contentManifold.GetValue(showInv);
            logoRect = new Rect(contentX * sW * 1.125f, sH, 4 * sW, sH);
            healthRect = new Rect(contentX * sW * 1.125f, 2*sH, 4 * sW, sH);
            moneyRect = new Rect(contentX * sW * 1.39f, 2 * sH, 4 * sW, sH);
            Rect healthContRect = new Rect(contentX * sW * 1.125f, 2.5f * sH, 4 * sW, sH);
            Rect moneyContRect = new Rect(contentX * sW * 1.39f, 2.5f * sH, 4 * sW, sH);
            GUI.Box(logoRect, "", Logo);
            GUI.Label(healthRect, "Health");
            GUI.Label(moneyRect, "Money");
            GUI.Label(healthContRect, "Castle.health");
            GUI.Label(moneyContRect, "Player.money");


            // Button
            float buttonX = buttonManifold.GetValue(showButton);
            Rect buttonRect = new Rect(buttonX * sW, 4 * sH, sW, sH);

            if (showButton)
            {
                if (GUI.Button(buttonRect, "Open", button))
                {
                    showInv = !showInv;
                    showButton = false;

                }
            }

            if (showInv)
            {
                if (GUI.Button(buttonRect, "Close", button))
                {
                    showInv = !showInv;
                    showButton = true;
                }
            }
            else
            {
                showButton = true;
            }
        }

    }
}

