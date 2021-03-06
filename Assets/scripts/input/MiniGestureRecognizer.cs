﻿using config;
using System;
using System.Collections;
using UnityEngine;

public class MiniGestureRecognizer : MonoBehaviour
{
    public event Action<Dir> Swipe;
    private bool swiping = false;
    private bool reversDir = true;
    private bool eventSent = false;
    private Vector2 lastPosition;

    private const float MIN_SWIPE_DIST = 3;

    private void Start()
    {
#if (UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER)
        Destroy(this);
#endif
    }

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (swiping == false)
            {
                swiping = true;
                lastPosition = Input.GetTouch(0).position;
                return;
            }
            else
            {
                if (!eventSent)
                {
                    if (Swipe != null)
                    {
                        Vector2 direction = Input.GetTouch(0).position - lastPosition;

                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        {
                            if (direction.x > MIN_SWIPE_DIST)
                                Swipe((reversDir) ? Dir.LEFT : Dir.RIGHT);
                            else if (direction.x < -MIN_SWIPE_DIST)
                                Swipe((reversDir) ? Dir.RIGHT : Dir.LEFT);

                        }
                        else
                        {
                            if (direction.y > MIN_SWIPE_DIST)
                                Swipe((reversDir) ? Dir.DOWN : Dir.UP);
                            else if (direction.y < -MIN_SWIPE_DIST)
                                Swipe((reversDir) ? Dir.UP : Dir.DOWN);
                        }

                        eventSent = true;
                    }
                }
            }
        }
        else
        {
            swiping = false;
            eventSent = false;
        }
    }
}