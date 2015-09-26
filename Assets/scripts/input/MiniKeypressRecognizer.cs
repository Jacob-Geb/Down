using config;
using System;
using System.Collections;
using UnityEngine;

public class MiniKeypressRecognizer : MonoBehaviour
{
    public event Action<Dir> KeyPress;

    private void Start()
    {
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
        Debug.Log( "destroyed");
        Destroy(this);
#endif
    }

    void Update()
    {
        if (KeyPress != null){
            if (Input.GetKeyDown(KeyCode.UpArrow))
            KeyPress(Dir.UP);
          if (Input.GetKeyDown(KeyCode.DownArrow))
            KeyPress(Dir.DOWN);
          if (Input.GetKeyDown(KeyCode.RightArrow))
            KeyPress(Dir.RIGHT);
          if (Input.GetKeyDown(KeyCode.LeftArrow))
              KeyPress(Dir.LEFT);
          }
    }
}