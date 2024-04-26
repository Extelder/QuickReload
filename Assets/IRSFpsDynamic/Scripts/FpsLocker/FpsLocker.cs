using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FpsLocker : MonoBehaviour
{
    private void Awake()
    {
        LockFps();
    }

    private void LockFps()
    {
        Application.targetFrameRate = 60;
    }
}