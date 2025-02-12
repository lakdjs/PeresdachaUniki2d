using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IDisposable
{
    private IInput _input;
    private IMovable _movable;

    public Movement(IInput input, IMovable movable)
    {
        _input = input;
        _movable = movable;

        Debug.Log(_input.GetType());
        Debug.Log(_movable.JumpPower);

        _input.ClickDown += OnClickDown;
        _input.ClickUp += OnClickUp;
    }

    public void Dispose()
    {
        _input.ClickDown -= OnClickDown;
        _input.ClickUp -= OnClickUp;
    }

    private void OnClickDown()
    {
        Debug.Log("ClickDown");
    }
    private void OnClickUp()
    {
        Debug.Log("ClickUp");
    }
}
