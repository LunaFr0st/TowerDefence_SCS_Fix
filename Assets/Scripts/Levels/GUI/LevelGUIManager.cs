using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class LevelGUIManager : MonoBehaviour
    {
        #region Variables
		[Header("Variables")]
		public int level;
		public int gold;
		public int castleHealth;
		public int enemiesRemain;
		#endregion

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
			// Main UI box
			GUI.Box(new Rect((12.21f * sW), 0, (4 * sW), Screen.height), "Test");
			//Title
			GUI.Box(new Rect((12.72f * sW), (0.4f * sH), (3 * sW), (0.6f * sH)), "4 Tower Defence");
			// Level text and box
			GUI.Box(new Rect((12.65f * sW), sH, (0.8f * sW), (0.8f * sH)), "Level");
			GUI.Box(new Rect((14.0f * sW), sH, (0.8f * sW), (0.8f * sH)), "<level>");
			// Gold text and box
			GUI.Box(new Rect((12.65f * sW), (2.0f * sH), (0.8f * sW), (0.8f * sH)), "Gold");
			GUI.Box(new Rect((14.0f * sW), (2.0f * sH), (0.8f * sW), (0.8f * sH)), "<gold>");
			// Castle health and bar
			GUI.Box(new Rect((12.72f * sW), (3.0f * sH), (3 * sW), (0.5f * sH)), "Castle Health");
			GUI.Box(new Rect((12.72f * sW), (3.5f * sH), (3 * sW), (0.5f * sH)), "<castleHealth>");
			// Remaining enemies text and box
			GUI.Box(new Rect((12.72f * sW), (4.25f * sH), (3 * sW), (0.5f * sH)), "Enemies Remaining");
			GUI.Box(new Rect((13.5f * sW), (4.75f * sH), (1.5f * sW), (0.5f * sH)), "E<enemiesRemain>");
			// Tower text and selection area
			GUI.Box(new Rect((12.72f * sW), (5.75f * sH), (3 * sW), (0.5f * sH)), "Towers");
			GUI.Button(new Rect((12.36f * sW), (6.5f * sH), (0.7f * sW), (0.7f * sH)), "BSE");
			GUI.Button(new Rect((13.11f * sW), (6.5f * sH), (0.7f * sW), (0.7f * sH)), "ETH");
			GUI.Button(new Rect((13.85f * sW), (6.5f * sH), (0.7f * sW), (0.7f * sH)), "WND");
			GUI.Button(new Rect((14.61f * sW), (6.5f * sH), (0.7f * sW), (0.7f * sH)), "FIR");
			GUI.Button(new Rect((15.36f * sW), (6.5f * sH), (0.7f * sW), (0.7f * sH)), "WTR");
        }
    }
}

