using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action ClickDown;
    public event Action ClickUp;

    public void Tick()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ClickDown.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            ClickUp.Invoke();
        }
    }
}
