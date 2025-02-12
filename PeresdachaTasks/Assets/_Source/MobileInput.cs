using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : IInput
{



    //логика на тачах
    public event Action ClickDown;
    public event Action ClickUp;
}
