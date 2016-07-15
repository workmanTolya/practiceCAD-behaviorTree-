using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    internal Rect buttonRect;
    internal Rect buttonRect1;

    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeigth = 60;
        Rect buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2), (1 * Screen.height / 3) - (buttonHeigth / 2), buttonWidth, buttonHeigth);
        if (GUI.Button(buttonRect, "Again"))
        {
            SceneManager.LoadScene("Stage1");
        }

        Rect buttonRect1 = new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeigth / 2), buttonWidth, buttonHeigth);
        if (GUI.Button(buttonRect1, "Main menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
