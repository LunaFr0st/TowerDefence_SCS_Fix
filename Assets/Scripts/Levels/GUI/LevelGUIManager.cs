using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
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
            public float smoothness = 2f;
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

        PlayersMoney playerMoney;
        CastleHealth castleHealth;
        EnemySpawner spawner;
        WaveModule wave;

        public string money;  //
        public bool waveStarted = false;
        public float timeSpeed = 2f;

        int sW; // Screen Width
        int sH; // Screen Height

        float health; // tower health

        bool showInv = false; // shows the Buy/Sell Menu in-game
        bool showButton = true; // enables/Disable the button for showing the buy/sell menu
        bool timeIncreaseToggle = false;
        Rect panelRect;
        Rect logoRect;
        Rect healthRect;
        Rect moneyRect;
        Vector2 scrollbar = Vector2.zero;


        //Functions
        void Awake()
        {
            playerMoney = GetComponent<PlayersMoney>();
            castleHealth = GetComponent<CastleHealth>();
            spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
            wave = GameObject.Find("WaveModule").GetComponent<WaveModule>();
        }

        private void Start()
        {

        }

        void Update()
        {
            sW = Screen.width / 16;
            sH = Screen.height / 9;
            Debug.Log(waveStarted);

        }
        void OnGUI()
        {
            // Constant Buttons
            if (!waveStarted)
            {
                if (GUI.Button(new Rect(0.5f * sW, 0.5f * sH, 0.5f * sW, 0.5f * sH), "Play"))
                {
                    waveStarted = true;
                    spawner.enemyLeftToSpawn = spawner.totalEnemies;
                }
            }
            else if (waveStarted)
            {
                if (GUI.Button(new Rect(0.5f * sW, 0.5f * sH, 0.5f * sW, 0.5f * sH), "Fast Forward"))
                {
                    timeIncreaseToggle = !timeIncreaseToggle;
                    if (timeIncreaseToggle)
                    {
                        Time.timeScale = timeSpeed;
                    }
                    else
                    {
                        Time.timeScale = 1f;
                    }
                }
            }




            // Background Panel
            float panelX = panelManifold.GetValue(showInv);
            panelRect = new Rect(panelX * sW, 0, 6.5f * sW, 9.5f * sH);
            GUI.Box(panelRect, "", background); // REKKKTTT

            // Content Panel - Declarations
            float contentX = contentManifold.GetValue(showInv);
            logoRect = new Rect(contentX * sW * 1.125f, sH, 4 * sW, sH);
            healthRect = new Rect(contentX * sW * 1.26f, 2.2f * sH, 4 * sW, sH);
            moneyRect = new Rect(contentX * sW * 1.125f, 3.25f * sH, 4 * sW, sH);

            Rect towerRect = new Rect(contentX * sW * 1.39f, 2 * sH, 4 * sW, sH);
            Rect healthContRect = new Rect(contentX * sW * 1.125f, 2.5f * sH, 4 * sW, 0.5f * sH);
            Rect moneyContRect = new Rect(contentX * sW * 1.25f, 3.25f * sH, 4 * sW, sH);

            // Content Panel - Placement
            GUI.Box(logoRect, "", Logo); // Logo
            GUI.Label(healthRect, "Castle Health"); // Castle's Health
            GUI.Box(healthContRect, "");
            GUI.Label(moneyRect, "Money"); // Money
            GUI.Label(moneyContRect, playerMoney.goldText + " G");


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

            // Tower Scrollbar on Content Panel
            scrollbar = GUI.BeginScrollView(towerRect, scrollbar, new Rect(sW, sH, sW, sH));

            GUI.EndScrollView();
        }

    }
}
