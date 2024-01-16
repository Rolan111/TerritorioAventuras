using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberarRaton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LiberarCursor();
    }

    void LiberarCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
