using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeigth = 60;
        Rect buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeigth / 2), buttonWidth, buttonHeigth);
        if (GUI.Button(buttonRect, "Main menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
