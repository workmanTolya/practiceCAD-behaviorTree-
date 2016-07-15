using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

    public Texture2D cursorTexture;
    public bool ccEnabled = false;

    void Start()
    {
        Invoke("SetCustomCursor", 0.1f);
    }

    void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        this.ccEnabled = false;
    }

    private void SetCustomCursor()
    {
        Cursor.SetCursor(this.cursorTexture, Vector2.zero, CursorMode.Auto);
        this.ccEnabled = true;
    }
}
