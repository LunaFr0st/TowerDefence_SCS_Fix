using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    #region Variables
    [Header("Bools")]
    public bool showOptions;
    public bool showPlay;
    public bool muteToggle;
    public bool fullScreenToggle;

    // this remembers the keycode of a key we are trying to change
    public KeyCode holdingKey;

    [Header("GUI Elements")]
    public GameObject menu;
    public GameObject options;
    public GUIStyle Logo = new GUIStyle();
    public GUIStyle BG = new GUIStyle();
    public GUIStyle Text = new GUIStyle();
    public GUIStyle smallText = new GUIStyle();

    [Header("Resolution Set & Screen Elements")]
    //public int index;
    //public int[] resX, resY;
    Resolution[] resolutions;
    public int sW, sH;
    #endregion

    // Use this for initialization
    void Start ()
    {
        sW = Screen.width / 16;
        sH = Screen.height / 9;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        Event e = Event.current;

        if (!showPlay) // If we are on our Main menu
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", BG); // background box
            GUI.Box(new Rect(4 * sW, 0.6f * sH, 8 * sW, 2 * sH), "", Logo); // title

            // Buttons
            if (GUI.Button(new Rect(6 * sW, 4 * sH, 4 * sW, sH), "Play", Text))
            {
                showPlay = true;
            }

            if (GUI.Button(new Rect(6 * sW, 6 * sH, 4 * sW, sH), "Exit", Text))
            {
                Application.Quit();
            }
        }

        else if (showPlay) // If we are on our Options menu
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", BG); // background box
            GUI.Box(new Rect(4 * sW, 0.25f * sH, 8 * sW, 2 * sH), "Level Select", Text); // title

            // Buttons
            if (GUI.Button(new Rect(6 * sW, 4 * sH, 4 * sW, sH), "Level 1", Text))
            {
                SceneManager.LoadScene(1);
            }

            if (GUI.Button(new Rect(6 * sW, 6 * sH, 4 * sW, sH), "Level 2", Text))
            {
                SceneManager.LoadScene(2);
            }

            if (GUI.Button(new Rect(14.875f * sW, 8.375f * sH, sW, 0.5f * sH), "Back", smallText))
            {
                showPlay = false;
            }

            // Set our aspect shiz if screen size changes
            if (sW != Screen.width / 16)
            {
                sW = Screen.width / 16;
                sH = Screen.height / 9;
            }
        }
    }
}
